using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
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
        
        public async Task<ActionResult<int>> CreateStaff(CreateStaffDTO dto)
        {
            //Check if User exists
            if (await UserExists(dto.UserName))
            {
                return new BadRequestObjectResult("Username Already Exists");
            }
            
            //Check if staff type exists
            if (!GlobalVariables.StaffTypes.Contains(dto.StaffType))
            {
                return new BadRequestObjectResult("Staff type is invalid, must be: " +
                                                  string.Join(", ", GlobalVariables.StaffTypes));
            }

            if (dto.SalonId>=0 && await SalonExists(dto.SalonId) is false)
            {
                return new BadRequestObjectResult("Salon doesn't exist");
            }

            // from Dto to Staff
            var newStaff = dto.ToNewStaff(_passwordHasher.HashPassword(null, dto.Password), dto.StaffType, dto.SalonId);

            //Save New User to Database
            var result = await _repositoryWrapper.Staff.CreateAsync(newStaff);

            //Save staff's role
            var role = dto.StaffType switch
            {
                GlobalVariables.StylistRole => GlobalVariables.StylistRole,
                GlobalVariables.BeauticianRole => GlobalVariables.BeauticianRole,
                _ => ""
            };
            var roleResult = await _repositoryWrapper.User.AddToRoleAsync(newStaff.User,role);
            if (!roleResult.Succeeded)
            {
                return new BadRequestObjectResult(roleResult.Errors);
            }

            return new OkObjectResult(result.Id);
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