using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IServiceService
    {
        Task<ActionResult<int>> CreateService(CreateServiceDTO createServiceDTO);
    }
}