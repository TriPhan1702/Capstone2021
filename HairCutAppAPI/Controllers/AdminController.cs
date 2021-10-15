using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
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
        [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
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