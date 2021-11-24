using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.ImageUpload;
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
        [Authorize]
        [HttpGet("active_salons")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerGetSalonList(CustomerGetSalonListDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CustomerGetSalonListDTO;
            
            return await _salonService.CustomerGetSalonList(dto);
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_salons")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetSalon(
            AdvancedGetSalonDTO advancedGetSalonDTO)
        {
            //Trim All Strings in object
            advancedGetSalonDTO = ObjectTrimmer.TrimObject(advancedGetSalonDTO) as AdvancedGetSalonDTO;
            var salons = await _salonService.AdvancedGetSalons(advancedGetSalonDTO);
            return salons;
        }

        /// <summary>
        /// For Admin create new salon
        /// </summary>
        /// <param name="createSalonDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
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
        
        /// <summary>
        /// For Admin to upload or update a salon's avatar
        /// </summary>
        /// <param name="dto">Id is Salon's Id</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPost("upload_salon_image")]
        public async Task<ActionResult<CustomHttpCodeResponse>> UploadSalonImage([FromForm] UploadImageDTO dto)
        {
            return await _salonService.UploadSalonImage(dto);
        }
        
        /// <summary>
        /// For Admin to update a salon,
        /// </summary>
        /// <param name="updateSalonDTO">Empty ot null fields will not be changed, negative number value = null</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("update_salon")]
        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateSalon([FromForm] UpdateSalonDTO updateSalonDTO)
        {
            //Trim All Strings in object
            updateSalonDTO = ObjectTrimmer.TrimObject(updateSalonDTO) as UpdateSalonDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _salonService.UpdateSalon(updateSalonDTO);
        }
        
        /// <summary>
        /// For admin to deactivate a salon
        /// </summary>
        /// <param name="id">Salon's id</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("deactivate_user/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> DeactivateSalon(int id)
        {
            return await _salonService.DeactivateSalon(id);
        }
    }
}