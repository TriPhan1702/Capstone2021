using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SalonDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ISalonService
    {
        Task<ActionResult<ICollection<CustomerGetSalonListDTO>>> CustomerGetSalonList();
        Task<ActionResult<CreateSalonResponseDTO>> CreateSalon(CreateSalonDTO salonDTO);
    }
}