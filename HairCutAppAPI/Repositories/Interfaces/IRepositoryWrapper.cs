using System.Threading.Tasks;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        //For saving multiple changes
        Task<bool> SaveAsync();

        IUserRepository User { get; }
    }
}