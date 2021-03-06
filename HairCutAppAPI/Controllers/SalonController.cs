using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class SalonController : BaseApiController
    {
        private readonly ISalonService _salonService;

        public SalonController(ISalonService salonService)
        {
            _salonService = salonService;
        }
        
        /// <summary>
        /// For Customer see list of available salons
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = GlobalVariables.RequireCustomerRole)]
        [HttpGet("active_salons")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerGetSalonList()
        {
            return await _salonService.CustomerGetSalonList();
        }

        /// <summary>
        /// For Admin create new salon
        /// </summary>
        /// <param name="createSalonDTO"></param>
        /// <returns></returns>
        [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPost("create_salon")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateSalon([FromBody] CreateSalonDTO createSalonDTO)
        {
            //Trim All Strings in object
            createSalonDTO = ObjectTrimmer.TrimObject(createSalonDTO) as CreateSalonDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _salonService.CreateSalon(createSalonDTO);
        }
    }
}