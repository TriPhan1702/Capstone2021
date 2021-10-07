using System;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class WorkSlotController : BaseApiController
    {
        private readonly IWorkSlotService _workSlotService;

        public WorkSlotController(IWorkSlotService workSlotService)
        {
            _workSlotService = workSlotService;
        }
        
        /// <summary>
        /// Get Id and status of a work slot based on staff, which slot, date
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireStylistRole)]
        // [Authorize(Policy = GlobalVariables.RequireBeauticianRole)]
        // [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpGet("get_work_slot")]
        public async Task<ActionResult<GetWorkSlotResponseDTO>> GetWorkSlot([FromBody] GetWorkSlotDTO getWorkSlotDTO)
        {
            //Trim All Strings in object
            getWorkSlotDTO = ObjectTrimmer.TrimObject(getWorkSlotDTO) as GetWorkSlotDTO;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            getWorkSlotDTO.Date = new DateTime(getWorkSlotDTO.Date.Year, getWorkSlotDTO.Date.Month, getWorkSlotDTO.Date.Day);

            return await _workSlotService.GetWorkSlot(getWorkSlotDTO);
        }

        /// <summary>
        /// Add an available slot if non have existed
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireStylistRole)]
        // [Authorize(Policy = GlobalVariables.RequireBeauticianRole)]
        // [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpPost("add_available_work_slot")]
        public async Task<ActionResult<int>> AddAvailableWorkSlot([FromBody] AddWorkSlotDTO addWorkSlotDTO)
        {
            //Trim All Strings in object
            addWorkSlotDTO = ObjectTrimmer.TrimObject(addWorkSlotDTO) as AddWorkSlotDTO;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            addWorkSlotDTO.Date = new DateTime(addWorkSlotDTO.Date.Year, addWorkSlotDTO.Date.Month, addWorkSlotDTO.Date.Day);

            return await _workSlotService.AddAvailableWorkSlot(addWorkSlotDTO);
        }
    }
}