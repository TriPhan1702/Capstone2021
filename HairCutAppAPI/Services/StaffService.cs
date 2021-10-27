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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StaffService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
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
            var newStaff = dto.ToNewStaff(dto.Password, dto.StaffType, dto.SalonId);
        
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
            var staff = await _repositoryWrapper.Staff.GetStaffDetail(userId);
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

            var staffs = await _repositoryWrapper.Staff.FindByConditionAsync(staff =>
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
            );
            
            //Map to result dto
            var result = staffs.Select(staff => new GetAvailableStylistsOfASalonInSpanOfDayResponseDTO() 
                {
                    StaffId = staff.Id, 
                    UserId = staff.UserId, 
                    Name = staff.FullName
                }).ToList();
            
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