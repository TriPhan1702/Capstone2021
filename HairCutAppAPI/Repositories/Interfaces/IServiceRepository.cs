using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Task<ICollection<int>> GetAllIdAsync();
    }
}