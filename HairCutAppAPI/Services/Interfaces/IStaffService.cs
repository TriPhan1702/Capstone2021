using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IStaffService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateStaff(CreateStaffDTO dto);
        
        Task<ActionResult<CustomHttpCodeResponse>> GetStaffDetail(int userId);
    }
}