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
        /// Get a service's detail, for staff, admin, manager
        /// </summary>
        /// <param name="id">Service Id</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpGet("{id}")] public async Task<ActionResult<CustomHttpCodeResponse>> GetServiceDetail(int id)
        {
            return await _serviceService.GetServiceDetail(id);
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_services")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetServices(
            AdvancedGetServiceDTO advancedGetServiceDTO)
        {
            //Trim All Strings in object
            advancedGetServiceDTO = ObjectTrimmer.TrimObject(advancedGetServiceDTO) as AdvancedGetServiceDTO;
            var services = await _serviceService.AdvancedGetServices(advancedGetServiceDTO);
            return services;
        }
        
        /// <summary>
        /// For Admin to create service
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPost("create_service")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateService([FromBody] CreateServiceDTO createServiceDTO)
        {
            //Trim All Strings in object
            createServiceDTO = ObjectTrimmer.TrimObject(createServiceDTO) as CreateServiceDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _serviceService.CreateService(createServiceDTO);
        }
        
        /// <summary>
        /// For Admin to update a service,
        /// </summary>
        /// <param name="updateServiceDto">Empty ot null fields will not be changed, negative price = null</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("update_service")]
        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateService([FromBody] UpdateServiceDto updateServiceDto)
        {
            //Trim All Strings in object
            updateServiceDto = ObjectTrimmer.TrimObject(updateServiceDto) as UpdateServiceDto;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _serviceService.UpdateService(updateServiceDto);
        }
        
        /// <summary>
        /// For Admin to get all services from database
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllServices()
        {
            return await _serviceService.GetAllServices();
        }

        [Authorize]
        [HttpGet("service_statuses")]
        public ActionResult<CustomHttpCodeResponse> GetServiceStatuses()
        {
            return new CustomHttpCodeResponse(200,"",GlobalVariables.ServiceStatuses);
        }
    }
}