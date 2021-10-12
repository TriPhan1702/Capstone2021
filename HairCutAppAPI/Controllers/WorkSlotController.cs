using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPost("find_work_slot")]
        public async Task<ActionResult<GetWorkSlotResponseDTO>> FindWorkSlot([FromBody] GetWorkSlotDTO getWorkSlotDTO)
        {
            //Trim All Strings in object
            getWorkSlotDTO = ObjectTrimmer.TrimObject(getWorkSlotDTO) as GetWorkSlotDTO;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _workSlotService.FindWorkSlot(getWorkSlotDTO);
        }

        /// <summary>
        /// Find All WorkSlots in a day of a staff, if end date is before start date then the dates will be swapped
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireStylistRole)]
        // [Authorize(Policy = GlobalVariables.RequireBeauticianRole)]
        // [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpPost("work_slot_of_day")]
        public async Task<ActionResult<ICollection<GetWorkSlotResponseDTO>>> FindWorkSlotsOfDay([FromBody]FindWorkSlotsOfDayDTO findWorkSlotsOfDayDTO)
        {
            //Trim All Strings in object
            findWorkSlotsOfDayDTO = ObjectTrimmer.TrimObject(findWorkSlotsOfDayDTO) as FindWorkSlotsOfDayDTO;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _workSlotService.FindWorkSlotsOfDay(findWorkSlotsOfDayDTO);
        }
        
        /// <summary>
        /// Find All WorkSlots in a span of days of a staff
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireStylistRole)]
        // [Authorize(Policy = GlobalVariables.RequireBeauticianRole)]
        // [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpPost("work_slot_of_time_span")]
        public async Task<ActionResult<ICollection<GetWorkSlotResponseDTO>>> FindWorkSlotsTimeSpan([FromBody] FindWorkSlotsOfTimeSpanDTO findWorkSlotsOfTimeSpanDTO)
        {
            //Trim All Strings in object
            findWorkSlotsOfTimeSpanDTO = ObjectTrimmer.TrimObject(findWorkSlotsOfTimeSpanDTO) as FindWorkSlotsOfTimeSpanDTO;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _workSlotService.FindWorkSlotsOfTimeSpan(findWorkSlotsOfTimeSpanDTO);
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
        /// Add multiple available slots
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireStylistRole)]
        // [Authorize(Policy = GlobalVariables.RequireBeauticianRole)]
        // [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpPost("add_available_work_slot_bulk")]
        public async Task<ActionResult<bool>> AddAvailableWorkSlot([FromBody] ICollection<AddWorkSlotDTO> addWorkSlotsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _workSlotService.AddAvailableWorkSlotBulk(addWorkSlotsDTO.Select(slot => ObjectTrimmer.TrimObject(slot) as AddWorkSlotDTO).ToList());
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