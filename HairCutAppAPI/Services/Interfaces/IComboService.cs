using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IComboService
    {
        Task<ActionResult<decimal>> GetComboPrice(int id);
        Task<ActionResult<List<ComboDTO>>> GetAllActiveCombos();
        Task<ActionResult<int>> CreateCombo(CreateComboDTO createComboDTO);
    }
}