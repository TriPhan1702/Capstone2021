using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IComboService
    {
        Task<ActionResult<int>> CreateCombo(CreateComboDTO createComboDTO);
    }
}