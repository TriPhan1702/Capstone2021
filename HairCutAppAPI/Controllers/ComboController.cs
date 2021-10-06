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
        /// For Admin to create new combo
        /// </summary>
        /// <param name="createComboDTO">If Services is null, then the combo created will have no service</param>
        /// <returns></returns>
        // [Authorize(Policy = GlobalVariables.RequireAdministratorRole)]
        [HttpPost("create_combo")]
        public async Task<ActionResult<int>> CreateCombo([FromForm] CreateComboDTO createComboDTO)
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