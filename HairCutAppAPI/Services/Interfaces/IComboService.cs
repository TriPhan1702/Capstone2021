using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IComboService
    {
        /// <summary>
        /// DEBUG
        /// </summary>
        Task<ActionResult<CustomHttpCodeResponse>> GetAllCombos();
        Task<ActionResult<CustomHttpCodeResponse>> GetComboDetail(int id);
        // Task<ActionResult<CustomHttpCodeResponse>> UpdateCombo(UpdateComboDTO updateComboDTO);
        Task<ActionResult<CustomHttpCodeResponse>> GetComboPrice(int id);
        Task<ActionResult<CustomHttpCodeResponse>> GetComboDuration(int id);
        Task<ActionResult<CustomHttpCodeResponse>> GetAllActiveCombos();
        Task<ActionResult<CustomHttpCodeResponse>> CreateCombo(CreateComboDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCombos(AdvancedGetCombosDTO advancedGetCombosDTO);
    }
}