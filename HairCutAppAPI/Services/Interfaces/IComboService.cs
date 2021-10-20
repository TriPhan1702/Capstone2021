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
        Task<ActionResult<CustomHttpCodeResponse>> UpdateCombo(UpdateComboDTO updateComboDTO);
        Task<ActionResult<CustomHttpCodeResponse>> GetComboPrice(int id);
        Task<ActionResult<CustomHttpCodeResponse>> GetAllActiveCombos();
        Task<ActionResult<CustomHttpCodeResponse>> CreateCombo(CreateComboDTO createComboDTO);
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCombos(AdvancedGetCombosDTO advancedGetCombosDTO);
    }
}