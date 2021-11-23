using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.StaffDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using HairCutAppAPI.Utilities.ImageUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public StaffService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateStaff(CreateStaffDTO dto)
        {
            //Check if User exists
            if (await UserExists(dto.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Email Already Exists");
            }
            
            //Check if staff type exists
            if (!GlobalVariables.StaffTypes.Contains(dto.StaffType))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Staff type is invalid, must be: " + string.Join(", ", GlobalVariables.StaffTypes)); 
            }
        
            if (dto.SalonId>=0 && await SalonExists(dto.SalonId) is false)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Salon doesn't exist");
            }
        
            // from Dto to Staff
            var newStaff = dto.ToNewStaff(dto.FullName, dto.Password, dto.StaffType, dto.SalonId);
            
            //If there's image
            if (dto.ImageFile != null)
            {
                var imageUploadResult = await _photoService.AppPhotoAsync(dto.ImageFile);
                //If there's error
                if (imageUploadResult.Error != null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
                }

                newStaff.User.AvatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            }
        
            //Save New User to Database
            var result = await _repositoryWrapper.Staff.CreateAsync(newStaff);
        
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Id == result.Id);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Created user not found");
            }
        
            return new CustomHttpCodeResponse(200,"", result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetStaffDetail(int userId)
        {
            var currentUserId = GetCurrentUserId();
            var currentUserRole = GetCurrentUserRole();

            //Get customer from database
            var staff = await _repositoryWrapper.Staff.GetStaffDetailFromUserId(userId);
            if (staff is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Staff with UserId {userId} not found");
            }

            return new CustomHttpCodeResponse(200, "", staff.ToStaffDetailDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetStaffs(AdvancedGetStaffDTO advancedGetStaffDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetStaffDTO.SortBy) && !AdvancedGetStaffDTO.OrderingParams.Contains(advancedGetStaffDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetStaffDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Staff.AdvancedGetStaffs(advancedGetStaffDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AddStaffToSalon(ChangeSalonStaffDTO changeSalonStaffDTO)
        {
            //Check if Salon Exists
            if (!await _repositoryWrapper.Salon.AnyAsync(salon => salon.Id == changeSalonStaffDTO.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with id {changeSalonStaffDTO.SalonId} not found");
            }

            var updatedStaff =
                await _repositoryWrapper.Staff.FindSingleByConditionAsync(staff =>
                    staff.Id == changeSalonStaffDTO.StaffId);
            if (updatedStaff is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Staff with id {changeSalonStaffDTO.StaffId} not found");
            }

            updatedStaff.SalonId = changeSalonStaffDTO.SalonId;
            var result = await _repositoryWrapper.Staff.UpdateAsync(updatedStaff, updatedStaff.Id);
            
            return new CustomHttpCodeResponse(200,$"Staff with id {changeSalonStaffDTO.StaffId} assigned to Salon with id {changeSalonStaffDTO.SalonId}",new ChangeSalonStaffDTO()
            {
                SalonId = updatedStaff.SalonId.Value,
                StaffId = updatedStaff.Id
            });
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> RemoveStaffFromSalon(int staffId)
        {
            var updatedStaff =
                await _repositoryWrapper.Staff.FindSingleByConditionAsync(staff =>
                    staff.Id == staffId);
            if (updatedStaff is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Staff with id {staffId} not found");
            }

            updatedStaff.SalonId = null;
            await _repositoryWrapper.Staff.UpdateAsync(updatedStaff, updatedStaff.Id);
            
            return new CustomHttpCodeResponse(200,$"Salon removed from staff",true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAvailableStylistsOfASalonInSpanOfDay(GetAvailableStylistsOfASalonInSpanOfDayDTO dto)
        {
            //Check if Salon Id is Valid
            if (!await  SalonExists(dto.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with id {dto.SalonId} not found");
            }
            
            //Parse start date and end date 
            var startDate = ParseDate(dto.StartDate);
            var endDate = ParseDate(dto.EndDate);

            var staffs = await _repositoryWrapper.Staff.FindByConditionAsyncWithInclude(staff =>
                //Find Staffs with same salon Id
                staff.SalonId == dto.SalonId &&
                //With active status
                staff.User.Status == GlobalVariables.ActiveUserStatus &&
                //That have work slot in the time span
                staff.WorkSlots.Any(slot =>
                    slot.Date >= startDate &&
                    slot.Date <= endDate &&
                    slot.Status == GlobalVariables.AvailableWorkSlotStatus) &&
                //That is a stylist
                staff.StaffType == GlobalVariables.StylistRole
            , staff => staff.User);
            
            //Map to result dto
            var result = staffs.Select(staff => staff.ToGetAvailableStylistsOfASalonInSpanOfDayResponseDTO()).ToList();
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetStylistListOfSalon(int salonId)
        {
            //Check if Salon Id is Valid
            if (!await  SalonExists(salonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with id {salonId} not found");
            }

            //Get Active Stylist that's in the salon
            var staffs =await _repositoryWrapper.Staff.FindByConditionAsync(staff => staff.SalonId == salonId &&
                                                                                staff.User.Status ==
                                                                                GlobalVariables.ActiveUserStatus);
            
            //Map from list of entities to list of dtos
            var result = staffs.Select(staff => staff.ToGetAvailableStylistsOfASalonInSpanOfDayResponseDTO()).ToList();
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateStaff(UpdateStaffDTO dto)
        {
            var currentUserId = GetCurrentUserId();

            var staff = await _repositoryWrapper.Staff.GetStaffDetailFromUserId(currentUserId);
            if (staff is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Customer with UserId {currentUserId} not found");
            }

            staff = dto.CompareAndUpdateStaff(staff);

            await _repositoryWrapper.Staff.UpdateAsync(staff, staff.Id);
            
            return new CustomHttpCodeResponse(200,"Staff profile updated", true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdministratorUpdateStaff(
            AdministratorUpdateStaffDTO dto)
        {
            var staff = await _repositoryWrapper.Staff.FindSingleByConditionAsync(sta => sta.Id == dto.StaffId);
            if (staff is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Không tìm thấy staff với Id {dto.StaffId}");
            }

            if (!string.IsNullOrWhiteSpace(dto.StaffType) && !GlobalVariables.StaffTypes.Contains(dto.StaffType.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Staff Type phải là: stylist, beautician" );
            }

            if (!string.IsNullOrWhiteSpace(dto.Status) && !GlobalVariables.UserStatuses.Contains(dto.Status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Staff Type phải là: " + string.Join(", ", GlobalVariables.UserStatuses));
            }

            if (dto.SalonId > 0 && !await _repositoryWrapper.Salon.AnyAsync(salon => salon.Id == dto.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Không tìm thấy salon với Id {dto.SalonId}");
            }

            await _repositoryWrapper.Staff.UpdateAsync(staff, staff.Id);
            
            return new CustomHttpCodeResponse(200,"Staff profile updated", true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAvailableStaffsForAppointment(int appointmentId)
        {
            //Get appointment from database
            var appointment =
                await _repositoryWrapper.Appointment.FindSingleByConditionWithIncludeAsync(app => app.Id == appointmentId, app => app.AppointmentDetails);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Appointment with Id {appointmentId} not found");
            }
            
            //Tìm các detail ko đc làm bởi stylist chính
            var appointmentDetails = appointment.AppointmentDetails.Where(detail => !detail.IsDoneByStylist);

            var result = new List<GetAvailableStaffForAppointmentResponseDTO>();
            //Tìm các slot of day appointment đã đi qua
            var slotsOfDay = (await _repositoryWrapper.SlotOfDay.FindByConditionAsync(slot =>
                slot.StartTime >= appointment.StartDate.TimeOfDay && slot.EndTime <= appointment.EndDate.TimeOfDay)).ToList();
            var slotofDayIds = slotsOfDay.Select(slot => slot.Id);
            
            var availableStaffIds = new HashSet<int>();
            
            //Đi qua từng detail của appointment và kiếm available staff
            foreach (var detail in appointmentDetails)
            {
                var responseObject = new GetAvailableStaffForAppointmentResponseDTO()
                {
                    AppointmentDetailId = detail.Id,
                    Staffs = new List<GetAvailableStaffForAppointmentResponseStaffDTO>()
                };

                //Tìm các slot of day service sẽ đi qua
                var detailSlotsOfDay = slotsOfDay.Where(slot =>
                    slot.StartTime >= detail.StartTime.TimeOfDay && slot.EndTime <= detail.EndTime.TimeOfDay).ToList();
                var detailSlotsOfDayIds = detailSlotsOfDay.Select(slot => slot.Id);
                
                //Kiếm các work slot available 
                var availableWorkSlots= (await _repositoryWrapper.WorkSlot.FindByConditionAsync(slot =>
                    //Có availalbe status
                    slot.Status == GlobalVariables.AvailableWorkSlotStatus &&
                    //Có slot of day appointment sẽ đi qua
                    detailSlotsOfDayIds.Contains(slot.SlotOfDayId) &&
                    //Cùng ngày với appointment
                    slot.Date.DayOfYear == appointment.StartDate.DayOfYear && 
                    //Cùng salon với appointment
                    slot.Staff.SalonId == appointment.SalonId)).ToList();

                //Kiếm các unique staff Id
                var availableWorkSlotsStaffIds = availableWorkSlots.Select(slot => slot.StaffId).ToHashSet();

                foreach (var staffId in availableWorkSlotsStaffIds)
                {
                    if (availableWorkSlots.Where(slot => slot.StaffId == staffId).ToList().Count == detailSlotsOfDay.Count)
                    {
                        //Thêm 1 staff ID vào response obbect, phần còn lại sẽ đc fill sau
                        responseObject.Staffs.Add(new GetAvailableStaffForAppointmentResponseStaffDTO()
                        {
                            StaffId = staffId
                        });
                        availableStaffIds.Add(staffId);
                    }
                }
                
                result.Add(responseObject);
            }
            
            

            //Nếu tìm đc ID của một số staff available, tìm thông tin của các staff đó
            if (availableStaffIds.Any())
            {
                var staffs =
                    (await _repositoryWrapper.Staff.FindByConditionAsyncWithInclude(staff =>
                        availableStaffIds.Contains(staff.Id), staff => staff.User)).ToList();
                //Map thông tin staff vào response
                foreach (var responseDTO in result)
                {
                    foreach (var staff in responseDTO.Staffs)
                    {
                        var tempStaff = staffs.FirstOrDefault(s => s.Id == staff.StaffId);
                        if (tempStaff == null) continue;
                        staff.Name = tempStaff.FullName;
                        staff.AvatarUrl = tempStaff.User.AvatarUrl;
                        staff.StaffType = tempStaff.StaffType;
                        staff.UserId = tempStaff.UserId;
                        //Tìm số appointment staff đó có ngày hốm đó
                        staff.NumberOfAppointmentsOnDate = await _repositoryWrapper.Appointment.CountAsync(app =>
                            //Appointment có detail có staff id giống
                            app.AppointmentDetails.Select(detail => detail.StaffId).Contains(tempStaff.Id) &&
                            //Appointment có cùng ngày với appointment hiện tại
                            app.StartDate.DayOfYear == appointment.StartDate.DayOfYear &&
                            //Không tính appointment đã cancel
                            app.Status != GlobalVariables.CanceledAppointmentStatus);
                    }
                }
            }
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        #region private functions

        //Check if user exists by username and email
        private async Task<bool> UserExists(string email)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }
        
        //Check if user exists by username and email
        private async Task<bool> SalonExists(int salonId)
        {
            return await _repositoryWrapper.Salon.AnyAsync(s => s.Id == salonId);
        }
        
        private int GetCurrentUserId()
        {
            int customerId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return customerId;
        }
        
        private string GetCurrentUserRole()
        {
            string role;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return role;
        }

        private DateTime ParseDate(string date)
        {
            try
            {
                return DateTime.ParseExact(date, GlobalVariables.DayFormat,
                    CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, e.Message);
            }
        }

        #endregion private functions
        
    }
}