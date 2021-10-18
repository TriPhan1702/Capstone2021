using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IStaffRepository : IRepositoryBase<Staff>
    {
        Task<Staff> GetStaffDetail(int userId);
    }
}