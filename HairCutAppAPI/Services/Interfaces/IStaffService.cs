using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.StaffDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IStaffService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateStaff(CreateStaffDTO dto);
        
        Task<ActionResult<CustomHttpCodeResponse>> GetStaffDetail(int userId);
        
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetStaffs(AdvancedGetStaffDTO advancedGetStaffDTO);
        Task<ActionResult<CustomHttpCodeResponse>> AddStaffToSalon(ChangeSalonStaffDTO changeSalonStaffDTO);
        Task<ActionResult<CustomHttpCodeResponse>> RemoveStaffFromSalon(int staffId);

        Task<ActionResult<CustomHttpCodeResponse>> GetAvailableStylistsOfASalonInSpanOfDay(
            GetAvailableStylistsOfASalonInSpanOfDayDTO dto);

        Task<ActionResult<CustomHttpCodeResponse>> GetStylistListOfSalon(int salonId);
    }
}