using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IServiceService
    {
        Task<UpdateServiceResponseDto> UpdateService(UpdateServiceDto updateServiceDto);
        Task<ActionResult<ICollection<ServiceDTO>>> GetAllServices();
        Task<ActionResult<int>> CreateService(CreateServiceDTO createServiceDTO);
    }
}