using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface ISalonRepository : IRepositoryBase<Salon>
    {
        Task<IEnumerable<Salon>> GetAllSalons();
        Task<PagedList<AdvancedGetSalonResponseDTO>> AdvancedGetSalons(AdvancedGetSalonDTO advancedGetUserDTO);
    }
}