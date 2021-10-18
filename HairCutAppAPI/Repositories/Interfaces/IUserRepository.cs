using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<AppUser>
    {
        Task<AppUser> GetUserByEmailAsync(string username);
        Task<bool> CheckRole(string email, string role);
    }
}