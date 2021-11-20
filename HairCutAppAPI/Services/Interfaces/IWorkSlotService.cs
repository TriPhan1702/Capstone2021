using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IWorkSlotService
    {
        /// <summary>
        /// DEBUG
        /// </summary>
        Task<ActionResult<CustomHttpCodeResponse>> GetAllWorkSlots();
        Task<ActionResult<CustomHttpCodeResponse>> FindWorkSlotsOfTimeSpan(FindWorkSlotsOfTimeSpanDTO findWorkSlotsOfTimeSpanDTO);
        Task<ActionResult<CustomHttpCodeResponse>> FindWorkSlotsOfDay(FindWorkSlotsOfDayDTO findWorkSlotsOfDayDTO);
        Task<ActionResult<CustomHttpCodeResponse>> FindOwnWorkSlotsOfDay(FindOwnWorkSlotsOfDayDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> FindWorkSlot(GetWorkSlotDTO getWorkSlotDTO);
        Task<ActionResult<CustomHttpCodeResponse>> AddAvailableWorkSlot(AddWorkSlotDTO addWorkSlotDTO);
        Task<ActionResult<CustomHttpCodeResponse>> AddAvailableWorkSlotBulk(ICollection<AddWorkSlotDTO> addWorkSlotsDTO);
        Task<ActionResult<CustomHttpCodeResponse>> UpdateWorkSlot(UpdateWorkSlotDTO updateWorkSlotDTO);
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetWorkSlots(AdvancedGetWorkSlotsDTO advancedGetWorkSlotsDTO);
        Task<ActionResult<CustomHttpCodeResponse>> PopulateWorkSlot(string date);
    }
}