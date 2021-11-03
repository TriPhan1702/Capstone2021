using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class ComboController : BaseApiController
    {
        private readonly IComboService _comboService;

        public ComboController(IComboService comboService)
        {
            _comboService = comboService;
        }
        
        /// <summary>
        /// DEBUG get all combos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllCombos()
        {
            return await _comboService.GetAllCombos();
        }
        
        /// <summary>
        /// Get Combo price from Combo Id
        /// </summary>
        /// <param name="id">Combo Id</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("combo_price/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetComboPrice(int id)
        {
            return await _comboService.GetComboPrice(id);
        }
        
        /// <summary>
        /// For Admin to create new combo
        /// </summary>
        /// <param name="createComboDTO">, if Services is null or empty, then the combo created will have no service</param>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPost("create_combo")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateCombo([FromBody] CreateComboDTO createComboDTO)
        {
            //Trim All Strings in object
            createComboDTO = ObjectTrimmer.TrimObject(createComboDTO) as CreateComboDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _comboService.CreateCombo(createComboDTO);
        }
        
        /// <summary>
        /// For Admin to update Combo Info
        /// </summary>
        /// <param name="updateComboDTO"> Empty ot null fields will not be changed, negative duration = null. If Services == null => no change, if Services is empty list => combo has no service</param>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("update_combo")]
        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateCombo([FromBody] UpdateComboDTO updateComboDTO)
        {
            //Trim All Strings in object
            updateComboDTO = ObjectTrimmer.TrimObject(updateComboDTO) as UpdateComboDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _comboService.UpdateCombo(updateComboDTO);
        }
        
        [Authorize]
        [HttpGet("combo_statuses")]
        public ActionResult<CustomHttpCodeResponse> GetComboStatuses()
        {
            return new CustomHttpCodeResponse(200,"", GlobalVariables.ComboStatuses);
        }
        
        /// <summary>
        /// Get a list of active Combos
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("active_combos")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllActiveCombos()
        {
            return await _comboService.GetAllActiveCombos();
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        // [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_combos")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCombos(
            AdvancedGetCombosDTO advancedGetCombosDTO)
        {
            //Trim All Strings in object
            advancedGetCombosDTO = ObjectTrimmer.TrimObject(advancedGetCombosDTO) as AdvancedGetCombosDTO;
            var combos = await _comboService.AdvancedGetCombos(advancedGetCombosDTO);
            return combos;
        }
    }
}