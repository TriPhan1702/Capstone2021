using System.Threading.Tasks;
using HairCutAppAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        // Task<IdentityResult> CreateUsingUserManagerAsync(AppUser user, string password);
    }
}