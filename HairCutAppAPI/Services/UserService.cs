using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities.Email;
using HairCutAppAPI.Utilities.Errors;
using HairCutAppAPI.Utilities.JWTToken;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;

namespace HairCutAppAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public UserService(IRepositoryWrapper repositoryWrapper, ITokenService tokenService, IConfiguration configuration, IEmailSender emailSender)
        {
            _repositoryWrapper = repositoryWrapper;
            _tokenService = tokenService;
            _configuration = configuration;
            _emailSender = emailSender;
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
            //Check if User exists
            if (await UserExists(dto.UserName))
            {
                return new BadRequestObjectResult("User Already Exists");
            }

            var newUser = new AppUser()
            {
                UserName = dto.UserName.ToLower(),
                Email = dto.Email
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
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.UserName == loginDto.UserName.ToLower() || u.Email == loginDto.UserName);
            if (user == null)
            {
                return new BadRequestObjectResult("Invalid UserName or Email");
            }
            
            //Check Password
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

        public async Task<ActionResult> ForgetPassword(string email)
        {
            //Search if user with this email exists
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Email == email);
            if (user == null)
            {
                return new BadRequestObjectResult("Invalid Password");
            }
            //Generate Password Reset Token
            var token = await _repositoryWrapper.User.GeneratePasswordResetTokenAsync(user);
             //Encode token again because the generated token sometimes contain special characters
            var validToken = EncodeToken(token);
            //Generate Url to change password
            var url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";
            var message = new EmailMessage(email, "Forget Password for HairCut App", $"To change your password go to the following link: <a href='{url}'>Click Here</a>");
            await _emailSender.SendEmailAsync(message);
            return new OkResult();
        }

        //Check if user exists by username and email
        private async Task<bool> UserExists(string username)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.UserName == username.ToLower() || u.Email == username);
        }

        //Turn a token provided by Identity Framework, which sometimes has special characters into valid token that the browser and parse
        private string EncodeToken(string token)
        {
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            return validToken;
        }
    }
}