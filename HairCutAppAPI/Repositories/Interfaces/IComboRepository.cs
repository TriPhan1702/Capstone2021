using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IComboRepository : IRepositoryBase<Combo>
    {
        Task<Combo> GetAComboComboDetails(int id);
        Task<IEnumerable<Combo>> GetCombosWithDetails();
        Task<Combo> GetOneComboWithDetails(int comboId);
        Task<Combo> GetOneComboWithDetailsAndServiceDetails(int comboId);
        Task<PagedList<AdvancedGetCombosResponseDTO>> AdvancedGetCombos(AdvancedGetCombosDTO advancedGetCombosDTO);
    }
}