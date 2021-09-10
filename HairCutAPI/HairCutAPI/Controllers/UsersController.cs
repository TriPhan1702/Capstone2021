using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HairCutAPI.Data;
using HairCutAPI.DTOs;
using HairCutAPI.Entities;
using HairCutAPI.Interfaces;
using HairCutAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        private readonly ITokenService _tokenService;

        public UsersController(IRepositoryWrapper repositoryWrapper, ITokenService tokenService)
        {
            _repositoryWrapper = repositoryWrapper;
            _tokenService = tokenService;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _repositoryWrapper.User.FindAllAsync();
            return users.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u=>u.Id == id);
            return user;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO dto)
        {
            if (await UserExists(dto.UserName))
            {
                return BadRequest("Username is taken");
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
                return BadRequest(result.Errors);
            }

            //Save User's role
            var roleResult = await _repositoryWrapper.User.AddToRoleAsync(newUser, "Customer");
            if (!roleResult.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new UserDTO()
            {
                Username = newUser.UserName,
                Token = await _tokenService.CreateToken(newUser)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            //Check if user exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.UserName == loginDto.UserName.ToLower());
            if (user == null)
            {
                return Unauthorized("Invalid Username");
            }

            var result = await _repositoryWrapper.User.CheckPasswordAsync(user, loginDto.Password);
            if (!result.Succeeded)
            {
                return Unauthorized();
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
