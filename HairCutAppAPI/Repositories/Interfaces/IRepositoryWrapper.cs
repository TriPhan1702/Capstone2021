using System.Threading.Tasks;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        //For saving multiple changes
        Task<bool> SaveAllAsync();

        void DeleteChanges();

        bool HasChanged();

        IUserRepository User { get; }
    }
}