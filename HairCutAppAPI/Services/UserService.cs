using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities.Errors;
using HairCutAppAPI.Utilities.JWTToken;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ITokenService _tokenService;

        public UserService(IRepositoryWrapper repositoryWrapper, ITokenService tokenService)
        {
            _repositoryWrapper = repositoryWrapper;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _repositoryWrapper.User.FindAllAsync();
            return users.ToList();
        }

        public async Task<ActionResult<AppUser>> FindById(int id)
        {
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Id == id);
            return user;
        }

        public async Task<ActionResult<UserDTO>> Register(RegisterDTO dto)
        {
            if (await UserExists(dto.UserName))
            {
                return new BadRequestObjectResult("User Already Exists");
            }

            using var hmac = new HMACSHA512();
            var newUser = new AppUser()
            {
                UserName = dto.UserName.ToLower(),
            };

            //Save New User to Database
            var result = await _repositoryWrapper.User.CreateUsingUserManagerAsync(newUser, dto.Password);
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }

            //Save User's role
            var roleResult = await _repositoryWrapper.User.AddToRoleAsync(newUser, "Customer");
            if (!roleResult.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }

            return new UserDTO()
            {
                Username = newUser.UserName,
                Token = await _tokenService.CreateToken(newUser)
            };
        }

        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            //Check if user exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.UserName == loginDto.UserName.ToLower());
            if (user == null)
            {
                return new BadRequestObjectResult("Invalid UserName");
            }

            var result = await _repositoryWrapper.User.CheckPasswordAsync(user, loginDto.Password);
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult("Invalid Password");
            }
            return new UserDTO()
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.UserName == username.ToLower());
        }
    }
}