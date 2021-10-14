using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SlotOfDayDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class SlotOfDayController : BaseApiController
    {
        private readonly ISlotOfDayService _slotOfDayService;

        public SlotOfDayController(ISlotOfDayService slotOfDayService)
        {
            _slotOfDayService = slotOfDayService;
        }
        
        /// <summary>
        /// Get all slots of a day
        /// </summary>
        /// <returns></returns>
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllSlotsOfDay()
        {
            return await _slotOfDayService.GetAllSlotsOfDay();
        }
    }
}