﻿using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Services.Interfaces;
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
        [HttpPost]
        public async Task<ActionResult<int>> CreateService([FromForm] CreateComboDTO createComboDTO)
        {
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _comboService.CreateCombo(createComboDTO);
        }
    }
}