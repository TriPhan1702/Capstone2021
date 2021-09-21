using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IAdminService
    {
        Task<ActionResult> CreateStaff(CreateStaffDTO createStaffDTO);
    }
}