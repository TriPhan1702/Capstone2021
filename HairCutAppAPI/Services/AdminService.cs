using System.Threading.Tasks;
using AutoMapper;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Email;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public AdminService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        
        public async Task<ActionResult> CreateStaff(CreateStaffDTO createStaffDTO)
        {
            //Check if User exists
            if (await UserExists(createStaffDTO.UserName))
            {
                return new BadRequestObjectResult("User Already Exists");
            }

            var newUser = _mapper.Map<AppUser>(createStaffDTO);

            //Save New User to Database
            var result = await _repositoryWrapper.User.CreateUsingUserManagerAsync(newUser, createStaffDTO.Password);
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }

            //Save User's role
            var roleResult = await _repositoryWrapper.User.AddToRoleAsync(newUser, GlobalVariables.StaffRole);
            if (!roleResult.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }

            return new OkResult();
        }
        
        //Check if user exists by username and email
        private async Task<bool> UserExists(string username)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.UserName == username.ToLower() || u.Email == username);
        }
    }
}