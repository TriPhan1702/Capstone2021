using System.Collections.Generic;
using System.Linq;
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
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPost("create_service")]
        public async Task<ActionResult<int>> CreateService([FromForm] CreateServiceDTO createServiceDTO)
        {
            //Trim All Strings in object
            createServiceDTO = ObjectTrimmer.TrimObject(createServiceDTO) as CreateServiceDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _serviceService.CreateService(createServiceDTO);
        }
        
        /// <summary>
        /// For Admin to update a service,
        /// </summary>
        /// <param name="updateServiceDto">Empty ot null fields will not be changed, negative price = null</param>
        /// <returns></returns>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPut("update_service")]
        public async Task<ActionResult<UpdateServiceResponseDto>> UpdateService([FromForm] UpdateServiceDto updateServiceDto)
        {
            //Trim All Strings in object
            updateServiceDto = ObjectTrimmer.TrimObject(updateServiceDto) as UpdateServiceDto;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _serviceService.UpdateService(updateServiceDto);
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

        // [Authorize]
        [HttpGet("service_statuses")]
        public ActionResult<ICollection<string>> GetServiceStatuses()
        {
            return GlobalVariables.ServiceStatuses;
        }
    }
}