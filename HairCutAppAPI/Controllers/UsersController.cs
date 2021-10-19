using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Extensions;
using HairCutAppAPI.Utilities.JWTToken;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// DEBUG: Get all User in Database
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole)]
        [HttpGet]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetUsers()
        {
            return await _userService.GetUsers();
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_users")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetUser(
            AdvancedGetUserDTO advancedGetUserDTO)
        {
            //Trim All Strings in object
            advancedGetUserDTO = ObjectTrimmer.TrimObject(advancedGetUserDTO) as AdvancedGetUserDTO;
            var users = await _userService.AdvancedGetUsers(advancedGetUserDTO);
            return users;
        }
        
        /// <summary>
        /// DEBUG: Find a user by their Id
        /// </summary>
        /// <param name="id">user's id</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _userService.FindById(id);
        }
        
        /// <summary>
        /// For all users to login, UserName can be UserName or Email
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<CustomHttpCodeResponse>> Login([FromBody] LoginDTO loginDto)
        {
            //Trim All Strings in object
            loginDto = ObjectTrimmer.TrimObject(loginDto) as LoginDTO;
            
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return await _userService.Login(loginDto);
        }
        //
        // /// <summary>
        // /// Generate Change Password Token And Email user
        // /// </summary>
        // /// <param name="email"></param>
        // /// <returns></returns>
        // [AllowAnonymous]
        // [HttpPost("forget_password/{email}")]
        // public async Task<ActionResult<CustomHttpCodeResponse>> ForgetPassword(string email)
        // {
        //     //Check input server side
        //     if (string.IsNullOrEmpty(email.Trim()))
        //     {
        //         return new CustomHttpCodeResponse(400,"Email is Blank");
        //     }
        //     
        //     return await _userService.ForgetPassword(email.Trim());
        // }
        //
        // /// <summary>
        // /// Reset User's Password
        // /// </summary>
        // /// <param name="resetPasswordDTO"></param>
        // /// <returns></returns>
        // [AllowAnonymous]
        // [HttpPost("reset_password")]
        // public async Task<ActionResult<CustomHttpCodeResponse>> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        // {
        //     return await _userService.ResetPassword(resetPasswordDTO);
        // }

        // [AllowAnonymous]
        // [HttpPost("google_login")]
        // public async Task<ActionResult<CustomHttpCodeResponse>> GoogleLogin([FromForm] GoogleUserDTO googleUserDTO)
        // {
        //     //Check input server side
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //
        //     return await _userService.LoginByGoogle(googleUserDTO.IdToken);
        // }
        //
        // [AllowAnonymous]
        // [HttpPost("facebook_login")]
        // public async Task<ActionResult<CustomHttpCodeResponse>> FacebookLogin([FromForm] FacebookUserDTO facebookUserDTO)
        // {
        //     //Check input server side
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //
        //     return await _userService.LoginByFacebook(facebookUserDTO.AccessToken);
        // }

        [AllowAnonymous]
        [HttpPost("social_login")]
        public async Task<ActionResult<CustomHttpCodeResponse>> SocialLogin([FromBody] SocialLoginDTO socialLoginDTO)
        {
            //Trim All Strings in object
            socialLoginDTO = ObjectTrimmer.TrimObject(socialLoginDTO) as SocialLoginDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
        
            switch (socialLoginDTO.Platform.Trim().ToLower())
            {
                case GlobalVariables.Google: return await _userService.LoginByGoogle(socialLoginDTO.Token);
                
                case GlobalVariables.Facebook: return await _userService.LoginByFacebook(socialLoginDTO.Token);
                
                case GlobalVariables.Apple: throw new NotImplementedException("Not Implemented yet");
                
                default: return BadRequest("Login Platform is invalid");
            }
        }
        
        
    }
}