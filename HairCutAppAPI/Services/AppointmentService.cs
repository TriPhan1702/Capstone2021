using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using HairCutAppAPI.Utilities.ImageUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AppointmentService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor,
            IPhotoService photoService)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        /// <summary>
        /// Debug
        /// </summary>
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppAppointments()
        {
            var appointments = await _repositoryWrapper.Appointment.FindAllAsync();
            return new CustomHttpCodeResponse(200, "", appointments);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllAppointmentStatuses()
        {
            return new CustomHttpCodeResponse(200, "", GlobalVariables.AppointmentStatuses.ToList());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAppointment(
            CreateAppointmentDTO createAppointmentDTO)
        {
            //Get Current User's Id
            var customerId = GetCurrentUserId();

            //Check if Customer exists, check role
            if (!await CheckUserOfRoleExists(customerId, GlobalVariables.CustomerRole))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Không tìm thấy Customer với Id {customerId}");
            }

            //Check if this customer already have an active appointment
            var existedAppointment =
                await _repositoryWrapper.Appointment.FindByConditionAsync(a =>
                    a.CustomerId == customerId && GlobalVariables.ActiveAppointmentStatuses.Contains(a.Status));
            //If there's such an appointment, abort
            if (existedAppointment != null && existedAppointment.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Cusotmer hiện tại đã có Appointment");
            }

            //Convert the chosen date from DTO from string to DateTime
            var chosenDate = DateTime.ParseExact(createAppointmentDTO.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            //Get Now Time
            var now = DateTime.Now;

            //Get Combo (with list of ComboDetail and ServiceDetail to use for adding Appointment Detail later) from database
            var combo =
                await _repositoryWrapper.Combo.GetOneComboWithDetailsAndServiceDetails(createAppointmentDTO.ComboId);
            //Check if Combo exists
            if (combo is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Khồng tìm thấy Combo với Id {createAppointmentDTO.ComboId}");
            }

            //Check if Combo is Empty
            if (!combo.ComboDetails.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Không thể đặt 1 combo đang không có service");
            }

            //Tính duration của Combo (Duration của tất cà service cộng lại)
            var comboDuration = combo.ComboDetails.Select(detail => detail.Service).ToList()
                .Sum(service => service.Duration);

            var chosenSlotsOfDayIds = new List<int>();
            //Get Id list of all the chosen Slots of Day base on the combo's duration
            for (var i = createAppointmentDTO.StartSlotOfDayId;
                i < createAppointmentDTO.StartSlotOfDayId + comboDuration;
                i++)
            {
                chosenSlotsOfDayIds.Add(i);
            }

            //Get Slot Of Day from the first to the last WorkSLot to calculate EndTime and compare chosen time with now
            var startSlotOfDay = await
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod => sod.Id == chosenSlotsOfDayIds.First());
            var endSlotOfDay = await
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod => sod.Id == chosenSlotsOfDayIds.Last());


            //If chosen date less than TimeToCreateAppointmentInAdvanced(Default 2) hours away, abort
            if (chosenDate.Add(startSlotOfDay.StartTime) <
                now.AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Thời gian được đặt phải cách hiện tại {GlobalVariables.TimeToCreateAppointmentInAdvanced} phút");
            }

            //Check if Salon exists
            if (!await SalonExists(createAppointmentDTO.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Không tìm thấy Salon với Id {createAppointmentDTO.SalonId}");
            }

            //Check if stylist exists
            var chosenStylist =
                await _repositoryWrapper.Staff.FindSingleByConditionAsync(staff =>
                    staff.Id == createAppointmentDTO.StylistStaffId && staff.StaffType == GlobalVariables.StylistRole);
            if (chosenStylist is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Không tìm thấy Stylist với Id {createAppointmentDTO.StylistStaffId}");
            }

            //Get all work slot that has the right SLotOfDayId, StaffId(Stylist's Id), of the correct date and is available
            var chosenWorkSlots = await
                _repositoryWrapper.WorkSlot.FindByConditionAsyncWithInclude(slot =>
                    chosenSlotsOfDayIds.Contains(slot.SlotOfDayId) &&
                    slot.StaffId == createAppointmentDTO.StylistStaffId &&
                    slot.Date.DayOfYear == chosenDate.DayOfYear &&
                    slot.Status == GlobalVariables.AvailableWorkSlotStatus, slot => slot.SlotOfDay) as List<WorkSlot>;

            //If no available work slot is found
            if (chosenWorkSlots is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"There's no available work slots for the chosen time");
            }

            //If the count of chosenSlots is not the same as chosenSlotsIds, then some slots are not available, abort
            if (chosenWorkSlots.Count != chosenSlotsOfDayIds.Count)
            {
                var unavailableSlots =
                    chosenWorkSlots.Select(s => s.SlotOfDayId).ToList().Except(chosenSlotsOfDayIds);
                var unavailableSlots2 =
                    chosenSlotsOfDayIds.Except(chosenWorkSlots.Select(s => s.SlotOfDayId).ToList());
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"The Following slots are not available: " + string.Join(", ", unavailableSlots) +
                    " The Following slots are not available: " + string.Join(", ", unavailableSlots2));
            }

            //If all chosen Work Slot are valid, change then status of each workslot to taken
            foreach (var workSlot in chosenWorkSlots)
            {
                //Change Status to Taken
                workSlot.Status = GlobalVariables.TakenWorkSlotStatus;
                await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(workSlot, workSlot.Id);
            }

            //Prepare new appointment
            var newAppointment = new Appointment()
            {
                SalonId = createAppointmentDTO.SalonId,
                CustomerId = customerId,
                Status = GlobalVariables.NewAppointmentStatus,
                StartDate = chosenDate.Add(startSlotOfDay.StartTime),
                EndDate = chosenDate.Add(endSlotOfDay.EndTime),
                CreatedDate = now,
                LastUpdated = now,
                ComboId = combo.Id,
                PaidAmount = 0,
                ChosenStaffId = chosenStylist.Id,
                AppointmentDetails = new List<AppointmentDetail>(),
                WorkSlots = chosenWorkSlots
            };
            foreach (var comboDetail in combo.ComboDetails)
            {
                //Map một phần của appointment detail mới
                var newAppointmentDetail = new AppointmentDetail()
                {
                    Price = comboDetail.Service.Price,
                    ServiceId = comboDetail.ServiceId,
                    IsDoneByStylist = comboDetail.IsDoneByStylist,
                    ServiceOrder = comboDetail.ServiceOrder
                };

                //Tìm xem service sẽ đi qua những slot of day nào (cộng lại duration của các service có order < combo detail hiện tại)
                var startSlotsOfDayOfDetailIndex = combo.ComboDetails
                    .Where(detail => detail.ServiceOrder < comboDetail.ServiceOrder)
                    .Sum(detail => detail.Service.Duration);
                //Tìm Id của Slot of day mà service sẽ đi qua, sắp xếp theo Slot of Day Id
                var slotsOfDayOfDetailIds =
                    chosenSlotsOfDayIds.GetRange(startSlotsOfDayOfDetailIndex, comboDetail.Service.Duration);
                newAppointmentDetail.WorkSlots = chosenWorkSlots
                    .Where(slot => slotsOfDayOfDetailIds.Contains(slot.SlotOfDayId)).OrderBy(slot => slot.SlotOfDayId).ToList();
                //Map giờ bắt đầu và giờ kết thúc của service
                newAppointmentDetail.StartTime =
                    chosenDate.Add(newAppointmentDetail.WorkSlots.First().SlotOfDay.StartTime);
                newAppointmentDetail.EndTime = chosenDate.Add(newAppointmentDetail.WorkSlots.Last().SlotOfDay.EndTime);

                //Gắn chosen stylist vào và gắn các workslot của chosen stylist vào
                if (comboDetail.IsDoneByStylist)
                {
                    newAppointmentDetail.StaffId = chosenStylist.Id;
                }

                //Thêm detail vào newAppointment ở trên
                newAppointment.AppointmentDetails.Add(newAppointmentDetail);
            }

            //Pend create change
            await _repositoryWrapper.Appointment.CreateWithoutSaveAsync(newAppointment);

            //Save appointment to database
            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went creating Appointment " + e.Message);
            }

            //Get Latest Appointment of customer
            var createdAppointment = await _repositoryWrapper.Appointment.GetLatestAppointmentOfCustomer(customerId);
            var price = await CalculateComboPrice(createAppointmentDTO.ComboId);

            //Send Appointment Created Notifications
            await SendAppointmentCreatedNotifications(createdAppointment, GetCurrentUserId(), chosenStylist?.UserId);

            return new CustomHttpCodeResponse(200, "Appointment Created",
                createdAppointment.ToCreateAppointmentResponseDTO(price, chosenStylist?.Id, chosenStylist?.FullName));
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CancelAppointment(int appointmentId)
        {
            //Find appointment in database
            var appointment = await _repositoryWrapper.Appointment.GetAppointmentWithDetail(appointmentId);

            //If appointment not found
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Appointment with Id {appointmentId} doesn't exist");
            }

            //Can't cancel already canceled or completed appointments
            if (appointment.Status == GlobalVariables.CanceledAppointmentStatus ||
                appointment.Status == GlobalVariables.CompleteAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Can't cancel already canceled or completed appointments");
            }

            //Get Current User's Id
            var userId = GetCurrentUserId();

            //Get User from database
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Id == userId);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Current User not found");
            }

            // If User is a customer
            if (user.Role.ToLower() == GlobalVariables.CustomerRole.ToLower())
            {
                var customer =
                    await _repositoryWrapper.Customer.FindSingleByConditionAsync(cus => cus.UserId == userId);
                if (customer is null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                        $"Customer with User Id {userId} not found");
                }

                //If Customer Id is not the same as appointment's user id, abort
                if (customer.Id != appointment.CustomerId)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                        $"Customer doesn't have appointment with Id {appointmentId}");
                }
            }

            //Get list of work slots associated with the staff and slot of day list
            var workSlots =
                await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws => ws.AppointmentId == appointmentId);

            var now = DateTime.Now;
            foreach (var slot in workSlots)
            {
                //If this work slot is less than TimeToCreateAppointmentInAdvanced(Default 2 hours) away, change status of that slot to not available, else set available
                slot.Status =
                    appointment.StartDate <= now.AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced)
                        ? GlobalVariables.NotAvailableWorkSlotStatus
                        : GlobalVariables.AvailableWorkSlotStatus;
                //Set appointment Id về null
                slot.AppointmentId = null;
                //Nếu Work slot có gắn với 1 appointment detail, set về null
                slot.AppointmentDetailId = null;
                //Pend change
                await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(slot, slot.Id);
            }

            //Change appointment's status and last update
            appointment.Status = GlobalVariables.CanceledAppointmentStatus;
            appointment.LastUpdated = DateTime.Now;

            var result = await _repositoryWrapper.Appointment.UpdateAsyncWithoutSave(appointment, appointment.Id);

            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went canceling Appointment " + e.Message);
            }

            return new CustomHttpCodeResponse(200, "", result.ToChangeAppointmentStatusResponseDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentDetail(int appointmentId)
        {
            //Get Current User's Id
            var currentUserId = GetCurrentUserId();

            var appointment =
                await _repositoryWrapper.Appointment.GetOneAppointmentWithCustomerAndSalonAndComboAndRating(
                    appointmentId);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment not found");
            }

            var details =
                await _repositoryWrapper.AppointmentDetail.GetAppointmentDetailWithStaffAndService(appointment.Id);

            appointment.AppointmentDetails = details.ToList();

            //If current User is a customer and the id doesn't match with the appointment's customer Id, abort
            if (await CheckUserOfRoleExists(currentUserId, GlobalVariables.CustomerRole) &&
                appointment.Customer.UserId != currentUserId)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Current user is not the owner of this appointment");
            }

            return new CustomHttpCodeResponse(200, "", appointment.ToGetAppointmentDetailResponseDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetAppointments(
            AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.SortBy) &&
                !AdvancedGetAppointmentsDTO.OrderingParams.Contains(advancedGetAppointmentsDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "OrderBy must be: " + string.Join(", ", AdvancedGetAppointmentsDTO.OrderingParams));
            }

            var result = await _repositoryWrapper.Appointment.AdvancedGetAppointments(advancedGetAppointmentsDTO);
            return new CustomHttpCodeResponse(200, "", result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetAppointments(
            CustomerAdvancedGetAppointmentDTO dto)
        {
            var currentUserId = GetCurrentUserId();

            if (!string.IsNullOrWhiteSpace(dto.SortBy) &&
                !CustomerAdvancedGetAppointmentDTO.OrderingParams.Contains(dto.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "OrderBy phải là: " + string.Join(", ", CustomerAdvancedGetAppointmentDTO.OrderingParams));
            }

            var result =
                await _repositoryWrapper.Appointment.AdvancedGetAppointments(
                    dto.ToAdvancedGetAppointmentsResponseDTO(currentUserId));
            return new CustomHttpCodeResponse(200, "", result);
        }

        public ActionResult<CustomHttpCodeResponse> GetSortByForAdvancedGetAppointments()
        {
            return new CustomHttpCodeResponse(200, "", AdvancedGetAppointmentsDTO.OrderingParams);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AssignStaff(AssignStaffDTO dto)
        {
            //Get Id of current user
            var currentUserId = GetCurrentUserId();

            //Get Appointment from database, with detail and staff information
            var appointment = await GetAppointmentWithDetailAndStaff(dto.AppointmentId);

            //Get Manager and Manager's User information
            var manager = await GetManagerWithUser(currentUserId);

            //Check if the current manager is from the salon
            if (manager.SalonId is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Tài khoản hiện tại ko có salon");
            }

            if (manager.SalonId != appointment.SalonId)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Tài khoản không phải là manager của Salon của Appointment");
            }

            //Tìm list Id của các staff của appointment
            //Nếu appointment mới tạo, count = 1
            var staffIdsFromAppointmentDetail =
                appointment.AppointmentDetails.Select(detail => detail.StaffId).ToList();
            //Tìm list Id của các staff từ dto
            var staffIdsFromDTO = dto.StaffDetailDTOs.Select(detail => detail.StaffId).ToList();

            //Check staff from dto if they are from the same salon, and is active
            var hasInvalidStaff = await _repositoryWrapper.Staff.AnyAsync(staff =>
                staffIdsFromDTO.Contains(staff.Id) && staff.User.Status != GlobalVariables.ActiveUserStatus &&
                staff.SalonId != appointment.SalonId);
            if (hasInvalidStaff)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "There's invalid staff in Request");
            }

            //Tìm các slot of day appointment đi qua
            var slotsOfDay = (await _repositoryWrapper.SlotOfDay.FindByConditionAsync(slot =>
                slot.StartTime >= appointment.StartDate.TimeOfDay && slot.EndTime <= appointment.EndDate.TimeOfDay)).ToList();

            var servicesNotDoneByChosenStylistIds =
                appointment.AppointmentDetails.Where(detail => !detail.IsDoneByStylist)
                    .Select(detail => detail.ServiceId);
            //Tìm list các service không phải do stylist đã chọn làm
            var appointmentDetails = appointment.AppointmentDetails
                .Where(detail => servicesNotDoneByChosenStylistIds.Contains(detail.ServiceId)).ToList();
            //Tìm list các service trong dto không phải do stylist đã chọn làm
            var appointmentDetailsFromDTO = dto.StaffDetailDTOs
                .Where(detail => servicesNotDoneByChosenStylistIds.Contains(detail.ServiceId)).ToList();

            var hasChanged = false;
            foreach (var detail in appointmentDetails)
            {
                //Find dto with the same Service Id as detail
                var dtoDetail =
                    dto.StaffDetailDTOs.FirstOrDefault(detailDTO => detailDTO.ServiceId == detail.ServiceId);

                if (dtoDetail is null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                        $"Request có thiếu service với Id {detail.ServiceId}");
                }

                //Nếu staff có thay đổi
                if (detail.StaffId != dtoDetail.StaffId)
                {
                    hasChanged = true;
                    if (detail.StaffId != null)
                    {
                        var oldWorkSlots = (await
                            _repositoryWrapper.WorkSlot.FindByConditionAsyncWithInclude(
                                slot => slot.AppointmentDetailId == detail.Id && slot.StaffId == detail.StaffId, slot => slot.SlotOfDay)).ToList();
                        //Deleted Old Work slot of old staff
                        foreach (var slot in oldWorkSlots)
                        {
                            slot.Status =
                                DateTime.Now.AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced) >=
                                slot.Date.Add(slot.SlotOfDay.StartTime)
                                    ? GlobalVariables.NotAvailableWorkSlotStatus
                                    : GlobalVariables.AvailableWorkSlotStatus;
                            slot.AppointmentId = null;
                            slot.AppointmentDetailId = null;

                            await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(slot, slot.Id);
                        }
                    }

                    //Nếu staff mới không phải là chosen staff
                    if (dtoDetail.StaffId != appointment.ChosenStaffId)
                    {
                        //Tìm các slot sẽ add, xếp theo thứ tự tăng Slot Of Day ID
                        var newWorkSlot =
                            (await _repositoryWrapper.WorkSlot.FindByConditionAsync(slot =>
                                slot.StaffId == dtoDetail.StaffId &&
                                slot.Status == GlobalVariables.AvailableWorkSlotStatus &&
                                slot.SlotOfDay.StartTime >= detail.StartTime.TimeOfDay &&
                                slot.SlotOfDay.EndTime <= detail.EndTime.TimeOfDay)).OrderBy(slot => slot.SlotOfDayId).ToList();

                        if (slotsOfDay.Count(slot => slot.StartTime >= detail.StartTime.TimeOfDay && slot.EndTime <= detail.EndTime.TimeOfDay) != newWorkSlot.Count)
                        {
                            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Staff với Id {dtoDetail.StaffId} không available từ {detail.StartTime.ToString(GlobalVariables.DateTimeFormat)} đến {detail.EndTime.ToString(GlobalVariables.DateTimeFormat)}");
                        }

                        foreach (var slot in newWorkSlot)
                        {
                            slot.Status = GlobalVariables.TakenWorkSlotStatus;
                            slot.AppointmentId = appointment.Id;
                            slot.AppointmentDetailId = detail.Id;
                            await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(slot, slot.Id);
                        }
                    }

                    //Replace the old staff Id with new one
                    detail.StaffId = dtoDetail.StaffId;
                }
            }

            //If there's no changes, abort
            if (!hasChanged)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "No changes can be made from the provided information");
            }

            appointment.LastUpdated = DateTime.Now;
            appointment.Status = GlobalVariables.ApprovedAppointmentStatus;
            await _repositoryWrapper.Appointment.UpdateAsyncWithoutSave(appointment, appointment.Id);


            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went assigning staff " + e.Message);
            }

            return new CustomHttpCodeResponse(200, "Staffs assigned", true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CheckAppointmentCanBeAssigned(int appointmentId)
        {
            var appointment =
                await _repositoryWrapper.Appointment.GetAppointmentWithComboDetail(appointmentId);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment not found");
            }

            if (appointment.Status != GlobalVariables.PendingAppointmentStatus &&
                appointment.Status != GlobalVariables.ApprovedAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Appointment is not a pending or approved appointment");
            }

            if (DateTime.Now.AddMinutes(GlobalVariables.TimeToConfirmAppointmentInAdvanced) >= appointment.StartDate)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Appointment cannot be approved because it is less that {GlobalVariables.TimeToConfirmAppointmentInAdvanced} minutes away");
            }

            return new CustomHttpCodeResponse(200, "", true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> FinishAppointment(FinishAppointmentDTO dto)
        {
            //Get appointment from database
            var appointment = await _repositoryWrapper.Appointment.FindSingleByConditionAsync(app => app.Id == dto.Id);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Appointment with Id {dto.Id} not found");
            }

            //Check if appointment is ongoing, if not, abort
            if (appointment.Status != GlobalVariables.OnGoingAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Appointment has to have {GlobalVariables.OnGoingAppointmentStatus} Status");
            }

            //Upload image
            var imageUploadResult = await _photoService.AppPhotoAsync(dto.Image);
            //If there's error
            if (imageUploadResult.Error != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, imageUploadResult.Error.Message);
            }

            //Change Appointment
            appointment.Status = GlobalVariables.CompleteAppointmentStatus;
            appointment.Note = dto.Note;
            appointment.ImageUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            appointment.LastUpdated = DateTime.Now;

            var result = await _repositoryWrapper.Appointment.UpdateAsync(appointment, appointment.Id);

            //TODO:Send notifications

            return new CustomHttpCodeResponse(200, "Appointment is completed", true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CheckCustomerHasCompletedAppointment()
        {
            var customerId = GetCurrentUserId();
            var customer =
                _repositoryWrapper.Customer.FindSingleByConditionAsync(customer1 => customer1.User.Id == customerId);
            if (customer is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    $"Customer with user Id {customerId} not found");
            }

            return new CustomHttpCodeResponse(200, "", await _repositoryWrapper.Appointment.AnyAsync(appointment =>
                appointment.CustomerId == customer.Id &&
                appointment.Status == GlobalVariables.CompleteAppointmentStatus));
        }

        private async Task<IEnumerable<WorkSlot>> GetWorkSlotsRelatedToStaff(Appointment appointment,
            ICollection<int> staffIds, ICollection<int> slotsOfDayIds, string status)
        {
            //Get the work slot of the staffs in dto
            var workSlots = (await _repositoryWrapper.WorkSlot.FindByConditionAsyncWithInclude(slot =>
                //Slots that has staff id in the staffId list
                staffIds.Contains(slot.StaffId) &&
                //Get available work slots
                slot.Status == status &&
                //That has the right slot of day
                slotsOfDayIds.Contains(slot.SlotOfDayId) &&
                //That is one the same day as the appointment
                slot.Date.DayOfYear == appointment.StartDate.DayOfYear, slot => slot.SlotOfDay)).ToList();
            if (!workSlots.Any())
            {
                switch (status)
                {
                    case GlobalVariables.TakenWorkSlotStatus:
                        throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                            "No Work Slots found for deleted Staffs");
                    case GlobalVariables.AvailableWorkSlotStatus:
                        throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                            "No Work Slots found for Added Staffs");
                }
            }

            return workSlots;
        }

        #region private functions

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

        /// <summary>
        /// Get Appointment from database, with detail and staff information
        /// </summary>
        /// <param name="id"></param>
        private async Task<Appointment> GetAppointmentWithDetailAndStaff(int id)
        {
            var appointment = await _repositoryWrapper.Appointment.GetAppointmentWithDetailAndStaff(id);

            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Appointment with Id {id} not found");
            }

            //Appointment can only be pending or approved
            if (appointment.Status == GlobalVariables.ApprovedAppointmentStatus &&
                DateTime.Now.AddMinutes(GlobalVariables.TimeToConfirmAppointmentInAdvanced) >= appointment.StartDate)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Appointment is less than {GlobalVariables.TimeToConfirmAppointmentInAdvanced} minutes away and staff cannot be reassigned");
            }

            if (appointment.Status != GlobalVariables.PendingAppointmentStatus &&
                appointment.Status != GlobalVariables.ApprovedAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Appointment is not pending or approved");
            }

            return appointment;
        }

        /// <summary>
        /// //Get Manager and Manager's User information
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        private async Task<Staff> GetManagerWithUser(int userId)
        {
            var manager = await _repositoryWrapper.Staff.FindSingleByConditionWithIncludeAsync(staff =>
                staff.StaffType == GlobalVariables.ManagerRole && staff.UserId == userId, staff => staff.User);
            if (manager is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Manager with UserId {userId} not found");
            }

            return manager;
        }

        /// <summary>
        /// Check if the services are the same from the appointment to dto
        /// </summary>
        private void CompareAssignStaffServices(IEnumerable<AppointmentDetail> appointmentDetails,
            IEnumerable<AssignStaffDetailDTO> assignStaffDetails)
        {
            var missingServiceIds = assignStaffDetails.Select(dtoDetail => dtoDetail.ServiceId)
                .Except(appointmentDetails.Select(detail => detail.ServiceId)).ToList();
            if (missingServiceIds.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Request thiếu các service: " + string.Join(", ", missingServiceIds));
            }
        }

        private async Task<bool> SalonExists(int salonId)
        {
            return await _repositoryWrapper.Salon.AnyAsync(s => s.Id == salonId);
        }

        private async Task<bool> SlotExists(int startSlotOfDayId)
        {
            return await _repositoryWrapper.SlotOfDay.AnyAsync(s => s.Id == startSlotOfDayId);
        }

        private async Task<bool> ComboExists(int comboId)
        {
            return await _repositoryWrapper.Combo.AnyAsync(c => c.Id == comboId);
        }

        private async Task<bool> CheckUserOfRoleExists(int userId, string role)
        {
            return await _repositoryWrapper.User.AnyAsync(user =>
                user.Id == userId && user.Role.ToLower() == role.ToLower());
        }

        private async Task CheckSlot(int startSlotOfDayId)
        {
            if (!await SlotExists(startSlotOfDayId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "SlotOfDay with the id {startSlotOfDayId doesn't exist}");
            }
        }

        /// <summary>
        /// Calculate the price of a combo base on comboId from its services
        /// </summary>
        private async Task<decimal> CalculateComboPrice(int comboId)
        {
            var comboDetails = await _repositoryWrapper.ComboDetail.FindComboDetailWithService(comboId);
            if (comboDetails is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "ComboDetails not found");
            }

            var price = comboDetails.Sum(comboDetail => comboDetail.Service.Price);
            return price;
        }

        private async Task<List<int>> SlotOfDayIdsFromStartTimeEndTime(Appointment appointment)
        {
            //Get start SlotOfDay
            var startSlotOfDay = await
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod =>
                    sod.StartTime == appointment.StartDate.TimeOfDay);
            if (startSlotOfDay is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Start slot not found");
            }

            //Get end SlotOfDay
            var endSlotOfDay = await
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod =>
                    sod.EndTime == appointment.EndDate.TimeOfDay);
            if (endSlotOfDay is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"End slot not found");
            }

            var slotsOfDayIds = new List<int>() {startSlotOfDay.Id};
            //Get list of Slot Of Day associated with the appointment
            for (var i = startSlotOfDay.Id; i <= endSlotOfDay.Id; i++)
            {
                slotsOfDayIds.Add(i);
            }

            return slotsOfDayIds;
        }

        private async Task SendAppointmentCreatedNotifications(Appointment appointment, int customerUserId,
            int? chosenStaffUserId = null)
        {
            //Prepare Customer's Notifications
            await _repositoryWrapper.Notification.CreateWithoutSaveAsync(ToNewAppointmentCreatedNotification(
                appointment,
                "Appointment Created Notification",
                "Appointment Created Notification",
                customerUserId));

            //Prepare Manager's Notifications
            var managers = (await _repositoryWrapper.Staff.FindByConditionAsync(staff =>
                    staff.StaffType == GlobalVariables.ManagerRole &&
                    staff.User.Status == GlobalVariables.ActiveUserStatus && staff.SalonId == appointment.SalonId))
                .ToList();
            if (managers.Any())
            {
                foreach (var manager in managers)
                {
                    await _repositoryWrapper.Notification.CreateWithoutSaveAsync(ToNewAppointmentCreatedNotification(
                        appointment,
                        "Appointment Created Notification",
                        "Appointment Created Notification",
                        manager.UserId));
                }
            }

            //Prepare Stylist's Notifications if one was chosen
            if (chosenStaffUserId != null)
            {
                await _repositoryWrapper.Notification.CreateWithoutSaveAsync(ToNewAppointmentCreatedNotification(
                    appointment,
                    "Appointment Created Notification",
                    "Appointment Created Notification",
                    chosenStaffUserId.Value));
            }

            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                //TODO: Log Failure
            }
        }

        private Notification ToNewAppointmentCreatedNotification(Appointment appointment, string title, string detail,
            int userId)
        {
            return new Notification()
            {
                Detail = detail,
                Status = GlobalVariables.PendingNotificationStatus,
                Title = title,
                Type = GlobalVariables.AppointmentCreatedNotification,
                AppointmentId = appointment.Id,
                UserId = userId,
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now,
            };
        }

        #endregion private functions
    }
}