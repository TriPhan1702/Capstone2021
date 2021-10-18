using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StaffService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
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
    }
}