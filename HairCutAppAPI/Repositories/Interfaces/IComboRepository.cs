using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IComboRepository : IRepositoryBase<Combo>
    {
        Task<Combo> GetAComboComboDetails(int id);
        Task<IEnumerable<Combo>> GetCombosWithDetails();
        Task<Combo> GetOneComboWithDetails(int comboId);
        Task<Combo> GetOneComboWithDetailsAndServiceDetails(int comboId);
    }
}