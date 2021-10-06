using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.JWTToken;
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

        [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        /// <summary>
        /// Find a user by their Id
        /// </summary>
        /// <param name="id">user's id</param>
        /// <returns></returns>
        [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [Authorize(Policy = GlobalVariables.RequireManagerRole)]
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
        public async Task<ActionResult<UserDTO>> Login([FromForm] LoginDTO loginDto)
        {
            //Trim All Strings in object
            loginDto = ObjectTrimmer.TrimObject(loginDto) as LoginDTO;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return await _userService.Login(loginDto);
        }

        /// <summary>
        /// Generate Change Password Token And Email user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("forget_password/{email}")]
        public async Task<ActionResult> ForgetPassword(string email)
        {
            //Check input server side
            if (string.IsNullOrEmpty(email.Trim()))
            {
                return BadRequest("Email is Blank");
            }
            
            return await _userService.ForgetPassword(email.Trim());
        }

        /// <summary>
        /// Reset User's Password
        /// </summary>
        /// <param name="resetPasswordDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("reset_password")]
        public async Task<ActionResult> ResetPassword([FromForm] ResetPasswordDTO resetPasswordDTO)
        {
            return await _userService.ResetPassword(resetPasswordDTO);
        }

        // [AllowAnonymous]
        // [HttpPost("google_login")]
        // public async Task<ActionResult<UserDTO>> GoogleLogin([FromForm] GoogleUserDTO googleUserDTO)
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
        // public async Task<ActionResult<UserDTO>> FacebookLogin([FromForm] FacebookUserDTO facebookUserDTO)
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
        public async Task<ActionResult<UserDTO>> SocialLogin([FromBody] SocialLoginDTO socialLoginDTO)
        {
            //Trim All Strings in object
            socialLoginDTO = ObjectTrimmer.TrimObject(socialLoginDTO) as SocialLoginDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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