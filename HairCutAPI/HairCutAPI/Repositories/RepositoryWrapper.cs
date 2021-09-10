using System.Threading.Tasks;
using HairCutAPI.Data;
using HairCutAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HairCutAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly HDBContext _context;
        private IUserRepository _user;
        private readonly UserManager<AppUser> _userManager;

        public RepositoryWrapper(UserManager<AppUser> userManager, HDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        //If something has been changed, return > 0
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        //Create concrete repositories if there aren't
        public IUserRepository User => _user ??= new UserRepository(_context, _userManager);
    }
}