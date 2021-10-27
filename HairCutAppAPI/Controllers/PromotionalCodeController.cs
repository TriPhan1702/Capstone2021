using System.Threading.Tasks;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class PromotionalCodeController : BaseApiController
    {
        private readonly IPromotionalCodeService _promotionalCodeService;

        public PromotionalCodeController(IPromotionalCodeService promotionalCodeService)
        {
            _promotionalCodeService = promotionalCodeService;
        }
        
        /// <summary>
        /// For admin to Create New Promotion Code
        /// </summary>
        // [Authorize(Policy = GlobalVariables.AdministratorRole)]
        [HttpPost("create_promotional_code")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreatePromotionalCode([FromBody]CreatePromotionalCodeDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CreatePromotionalCodeDTO;
            
            //Validate form
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return new CustomHttpCodeResponse(200,"", await _promotionalCodeService.CreatePromotionalCode(dto));
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_code")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetPromotionalCode(
            AdvancedGetPromotionalCodesDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as AdvancedGetPromotionalCodesDTO;
            var codes = await _promotionalCodeService.AdvancedGetPromotionalCodes(dto);
            return codes;
        }
        
        /// <summary>
        /// For Admin to update a promotional code
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("update_code")]
        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateSalon([FromBody] UpdatePromotionalCodeDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as UpdatePromotionalCodeDTO;

            return await _promotionalCodeService.UpdatePromotionalCode(dto);
        }
    }
}