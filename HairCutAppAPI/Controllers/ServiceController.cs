using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class ServiceController : BaseApiController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        
        /// <summary>
        /// For Admin to create service
        /// </summary>
        /// <param name="createServiceDTO"></param>
        /// <returns></returns>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPost("create_service")]
        public async Task<ActionResult<int>> CreateService([FromForm] CreateServiceDTO createServiceDTO)
        {
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _serviceService.CreateService(createServiceDTO);
        }
        
        /// <summary>
        /// For Admin to get all services from database
        /// </summary>
        /// <returns></returns>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpGet]
        public async Task<ActionResult<ICollection<ServiceDTO>>> GetAllServices()
        {
            return await _serviceService.GetAllServices();
        }
        
    }
}