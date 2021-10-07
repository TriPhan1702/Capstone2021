using System;
using System.Collections.Generic;
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

            return await _workSlotService.AddAvailableWorkSlot(addWorkSlotDTO);
        }

        /// <summary>
        /// Update status of a WorkSlot
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireStylistRole)]
        // [Authorize(Policy = GlobalVariables.RequireBeauticianRole)]
        // [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpPut("update_work_slot")]
        public async Task<ActionResult<UpdateWorkSlotDTO>> UpdateWorkSlot(UpdateWorkSlotDTO updateWorkSlotDTO)
        {
            //Trim All Strings in object
            updateWorkSlotDTO = ObjectTrimmer.TrimObject(updateWorkSlotDTO) as UpdateWorkSlotDTO;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _workSlotService.UpdateWorkSlot(updateWorkSlotDTO);
        }
        
        // [Authorize]
        [HttpGet("work_slot_statuses")]
        public ActionResult<ICollection<string>> GetWorkSlotStatuses()
        {
            return GlobalVariables.WorkSlotStatuses;
        }
    }
}