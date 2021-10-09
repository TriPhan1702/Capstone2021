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
        
        // [Authorize]
        [HttpGet("combo_price/{id}")]
        public async Task<ActionResult<decimal>> GetComboPrice(int id)
        {
            return await _comboService.GetComboPrice(id);
        }
        
        /// <summary>
        /// For Admin to create new combo, if Services is null, then the combo created will have no service
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPost("create_combo")]
        public async Task<ActionResult<int>> CreateCombo([FromBody] CreateComboDTO createComboDTO)
        {
            //Trim All Strings in object
            createComboDTO = ObjectTrimmer.TrimObject(createComboDTO) as CreateComboDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _comboService.CreateCombo(createComboDTO);
        }
        
        /// <summary>
        /// For Admin to update Combo Info, empty ot null fields will not be changed, negative duration = null
        /// </summary>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPut("update_combo")]
        public async Task<ActionResult<UpdateComboResponseDTO>> UpdateCombo([FromBody] UpdateComboDTO updateComboDTO)
        {
            //Trim All Strings in object
            updateComboDTO = ObjectTrimmer.TrimObject(updateComboDTO) as UpdateComboDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _comboService.UpdateCombo(updateComboDTO);
        }
        
        // [Authorize]
        [HttpGet("combo_statuses")]
        public ActionResult<ICollection<string>> GetComboStatuses()
        {
            return GlobalVariables.ComboStatuses;
        }
        
        [HttpGet("active_combos")]
        public async Task<ActionResult<List<ComboDTO>>> GetAllActiveCombos()
        {
            return await _comboService.GetAllActiveCombos();
        }
    }
}