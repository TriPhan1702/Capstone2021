using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SlotOfDayDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ISlotOfDayService
    {
        Task<ActionResult<CustomHttpCodeResponse>> GetAllSlotsOfDay();
    }
}