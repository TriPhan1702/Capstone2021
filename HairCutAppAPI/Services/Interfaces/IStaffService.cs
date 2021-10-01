using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IStaffService
    {
        Task<ActionResult<int>> CreateStaff(CreateStaffDTO dto);
    }
}