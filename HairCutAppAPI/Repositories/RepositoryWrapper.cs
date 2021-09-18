using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly HDBContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private IUserRepository _user;
        private readonly UserManager<AppUser> _userManager;

        public RepositoryWrapper(UserManager<AppUser> userManager, HDBContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        //If something has been changed, return > 0
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        //Create concrete repositories if there aren't
        public IUserRepository User => _user ??= new UserRepository(_context, _userManager, _signInManager);
    }
}