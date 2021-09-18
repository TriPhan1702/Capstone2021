using System.Threading.Tasks;
using HairCutAppAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<AppUser>
    {
        Task<AppUser> GetUserByUserNameAsync(string username);
        Task<IdentityResult> CreateUsingUserManagerAsync(AppUser user, string password);
        Task<IdentityResult> AddToRoleAsync(AppUser user, string role);
        Task<SignInResult> CheckPasswordAsync(AppUser user, string password);
    }
}