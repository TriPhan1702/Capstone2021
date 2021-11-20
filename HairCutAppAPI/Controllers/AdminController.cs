using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CorePush.Google;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IPushNotification _pushNotification;

        public AdminController(IUserService userService, IPushNotification pushNotification)
        {
            _userService = userService;
            _pushNotification = pushNotification;
        }
        
        /// <summary>
        /// Used by admin to create other admin accounts
        /// </summary>
        [Authorize(Policy = GlobalVariables.AdministratorRole)]
        [HttpPost("create_admin")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAdmin([FromForm]CreateUserDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CreateUserDTO;
            //Validate form
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return new CustomHttpCodeResponse(200,"", await _userService.CreateUser(dto, GlobalVariables.AdministratorRole));
        }
    }
}