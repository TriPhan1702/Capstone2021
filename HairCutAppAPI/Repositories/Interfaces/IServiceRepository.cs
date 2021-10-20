using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Task<ICollection<int>> GetAllIdAsync();
        Task<PagedList<ServiceDTO>> AdvancedGetServices(AdvancedGetServiceDTO advancedGetServiceDTO);
    }
}