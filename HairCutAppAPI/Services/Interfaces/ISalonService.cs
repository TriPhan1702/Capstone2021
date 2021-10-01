using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SalonDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ISalonService
    {
        Task<ActionResult<CreateSalonResponseDTO>> CreateSalon(CreateSalonDTO salonDTO);
    }
}