
using System.Linq;
using System.Threading.Tasks;
using HairCutAPI.Data;
using HairCutAPI.DTOs;
using HairCutAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAPI.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        private readonly HDBContext _hdbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(HDBContext hdbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(hdbContext)
        {
            _hdbContext = hdbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await _hdbContext.Users.SingleOrDefaultAsync(u=>u.UserName == username);
        }

        public async Task<IdentityResult> CreateUsingUserManagerAsync(AppUser user, string password)
        {
            //Save New User to Database
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(AppUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, "Customer");
        }

        public async Task<SignInResult> CheckPasswordAsync(AppUser user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

    }
}
