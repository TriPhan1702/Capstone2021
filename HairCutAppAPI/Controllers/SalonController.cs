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
        
        // [Authorize(Policy = GlobalVariables.RequireCustomerRole)]
        [HttpGet]
        public async Task<ActionResult<List<CustomerGetSalonListDTO>>> CustomerGetSalonList()
        {
            return await _salonService.CustomerGetSalonList();
        }

        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPost("create_salon")]
        public async Task<ActionResult<CreateSalonResponseDTO>> CreateSalon([FromForm] CreateSalonDTO createSalonDTO)
        {
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _salonService.CreateSalon(createSalonDTO);
        }
    }
}