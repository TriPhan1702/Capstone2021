using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IWorkSlotService
    {
        Task<ActionResult<GetWorkSlotResponseDTO>> GetWorkSlot(GetWorkSlotDTO getWorkSlotDTO);
        Task<ActionResult<int>> AddAvailableWorkSlot(AddWorkSlotDTO addWorkSlotDTO);
        Task<ActionResult<UpdateWorkSlotDTO>> UpdateWorkSlot(UpdateWorkSlotDTO updateWorkSlotDTO);
    }
}