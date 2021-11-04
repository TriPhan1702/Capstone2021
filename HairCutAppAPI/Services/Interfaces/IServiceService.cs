using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IServiceService
    {
        Task<CustomHttpCodeResponse> UpdateService(UpdateServiceDto updateServiceDto);
        Task<ActionResult<CustomHttpCodeResponse>> GetAllServices();
        Task<ActionResult<CustomHttpCodeResponse>> GetServiceDetail(int id);
        Task<ActionResult<CustomHttpCodeResponse>> CreateService(CreateServiceDTO createServiceDTO);
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetServices(AdvancedGetServiceDTO advancedGetServiceDTO);
    }
}