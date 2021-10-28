using System.Threading.Tasks;
using HairCutAppAPI.DTOs.StaffDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IStaffRepository : IRepositoryBase<Staff>
    {
        Task<Staff> GetStaffDetailFromUserId(int userId);
        Task<PagedList<AdvancedGetStaffResponseDTO>> AdvancedGetStaffs(AdvancedGetStaffDTO advancedGetUserDTO);
    }
}