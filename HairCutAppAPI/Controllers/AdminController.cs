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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    //TODO: Rewrite this
    public class AdminController : BaseApiController
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        /// Used by admin to create other admin accounts
        /// </summary>
        [Authorize(Policy = GlobalVariables.AdministratorRole)]
        [HttpPost("create_admin")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAdmin([FromBody]CreateUserDTO dto)
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

        /// <summary>
        /// Used to test notification
        /// </summary>
        [HttpGet("test_notification")]
        public async Task<FcmResponse> TestNotification(string deviceToken)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://fcm.googleapis.com/fcm/"),
            };
            
            var notification = new GoogleNotification()
            {
                Data = new GoogleNotification.DataPayload(){Message = "Notification sent from DMT App"},
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var fcm = new FcmSender(new FcmSettings(){ServerKey = @"AAAA8-N5Dnk:APA91bFjvbPNga7NDSsMYPHfa6o5OIzTM64WUn9CLct1-7lybapkewfwc-PrsrSiOwxCy1J-L5OTPcEasvmmc8lqNlgaZ_7Xv6ap-gkOeyZEZL_3l-HgtRgLsmxn5N6sp5xe1IqCtOVq", SenderId = "1047493414521"}, 
                httpClient);
            return await fcm.SendAsync(deviceToken, notification);
        }
        
        
        // /// <summary>
        // /// Change the user the specified roles
        // /// </summary>
        // /// <param name="username"></param>
        // /// <param name="roles">Can have many roles, each role name is separated by ","</param>
        // /// <returns></returns>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        // [HttpPost("edit-role/{username}")]
        // public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        // {
        //     var selectedRoles = roles.Split(",").ToList();
        //     var user = await _userManager.FindByNameAsync(username);
        //     var userRoles = await _userManager.GetRolesAsync(user);
        //     var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
        //
        //     if (!result.Succeeded)
        //     {
        //         return BadRequest("Failed to add user to roles");
        //     }
        //
        //     result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
        //
        //     if (!result.Succeeded)
        //     {
        //         return BadRequest("Failed to remove user from roles");
        //     }
        //
        //     return Ok();
        // }
    }
}