using System.Threading.Tasks;

namespace HairCutAPI.Repositories
{
    public interface IRepositoryWrapper
    {
        //For saving multiple changes
        Task<bool> SaveAsync();

        IUserRepository User { get; }
    }
}