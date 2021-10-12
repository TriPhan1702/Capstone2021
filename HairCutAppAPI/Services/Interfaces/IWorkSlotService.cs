using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IWorkSlotService
    {
        Task<ActionResult<ICollection<GetWorkSlotResponseDTO>>> FindWorkSlotsOfTimeSpan(FindWorkSlotsOfTimeSpanDTO findWorkSlotsOfTimeSpanDTO);
        Task<ActionResult<ICollection<GetWorkSlotResponseDTO>>> FindWorkSlotsOfDay(FindWorkSlotsOfDayDTO findWorkSlotsOfDayDTO);
        Task<ActionResult<GetWorkSlotResponseDTO>> FindWorkSlot(GetWorkSlotDTO getWorkSlotDTO);
        Task<ActionResult<int>> AddAvailableWorkSlot(AddWorkSlotDTO addWorkSlotDTO);
        Task<ActionResult<bool>> AddAvailableWorkSlotBulk(ICollection<AddWorkSlotDTO> addWorkSlotsDTO);
        Task<ActionResult<UpdateWorkSlotDTO>> UpdateWorkSlot(UpdateWorkSlotDTO updateWorkSlotDTO);
    }
}