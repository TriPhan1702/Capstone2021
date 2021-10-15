using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class ManagerController : BaseApiController
    {
        private readonly IUserService _userService;

        public ManagerController(IUserService userService)
        {
            _userService = userService;
        }
        
        // /// <summary>
        // /// Used Admin the create manager
        // /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        // [HttpPost("create_manager")]
        // public async Task<ActionResult<CustomHttpCodeResponse>> CreateManager([FromForm]CreateUserDTO dto)
        // {
        //     //Trim All Strings in object
        //     dto = ObjectTrimmer.TrimObject(dto) as CreateUserDTO;
        //     //Validate form
        //     if (!ModelState.IsValid)
        //     {
        //         return new CustomHttpCodeResponse(400,"",ModelState);
        //     }
        //     
        //     return await _userService.CreateUser(dto, GlobalVariables.ManagerRole);
        // }
    }
}