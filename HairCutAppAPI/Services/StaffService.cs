using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
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
    }
}