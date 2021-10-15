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
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public StaffService(IRepositoryWrapper repositoryWrapper, IPasswordHasher<AppUser> passwordHasher)
        {
            _repositoryWrapper = repositoryWrapper;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateStaff(CreateStaffDTO dto)
        {
            //Check if User exists
            if (await UserExists(dto.UserName))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Username Already Exists");
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
            var newStaff = dto.ToNewStaff(_passwordHasher.HashPassword(null, dto.Password), dto.StaffType, dto.SalonId);

            //Save New User to Database
            var result = await _repositoryWrapper.Staff.CreateAsync(newStaff);

            //Save staff's role
            string role;
            switch (dto.StaffType.ToLower())
            {
                case GlobalVariables.StylistRole:
                    role = GlobalVariables.StylistRole;
                    break;
                case GlobalVariables.BeauticianRole:
                    role = GlobalVariables.BeauticianRole;
                    break;
                case GlobalVariables.ManagerRole:
                    role = GlobalVariables.ManagerRole;
                    break;
                default:
                    return new BadRequestObjectResult("Staff type is invalid, must be: " +
                                                      string.Join(", ", GlobalVariables.StaffTypes));
            }

            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(appUser => appUser.Id == result.Id);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Created user not found");
            }

            var roleResult = await _repositoryWrapper.User.AddToRoleAsync(user,role);
            if (!roleResult.Succeeded)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, roleResult.Errors.ToString());
            }

            return new CustomHttpCodeResponse(200,"", result.Id);
        }
        
        //Check if user exists by username and email
        private async Task<bool> UserExists(string username)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.UserName == username.ToLower());
        }
        
        //Check if user exists by username and email
        private async Task<bool> SalonExists(int salonId)
        {
            return await _repositoryWrapper.Salon.AnyAsync(s => s.Id == salonId);
        }
    }
}