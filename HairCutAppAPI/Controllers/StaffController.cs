using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class StaffController : BaseApiController
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        
        /// <summary>
        /// Get profile of a staff
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [Authorize(Policy = GlobalVariables.RequireStylistRole)]
        [Authorize(Policy = GlobalVariables.RequireBeauticianRole)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetStaffDetail(int id)
        {
            return await _staffService.GetStaffDetail(id);
        }
        
        /// <summary>
        /// For Admin to create staff
        /// </summary>
        /// <param name="createStaffDTO"></param>
        /// <returns></returns>
        [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPost("create_staff")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateStaff([FromBody] CreateStaffDTO createStaffDTO)
        {
            //Trim All Strings in object
            createStaffDTO = ObjectTrimmer.TrimObject(createStaffDTO) as CreateStaffDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
        
            return await _staffService.CreateStaff(createStaffDTO);
        }
    }
}