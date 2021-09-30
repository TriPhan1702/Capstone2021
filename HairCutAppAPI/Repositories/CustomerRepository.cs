using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly HDBContext _hdbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CustomerRepository(HDBContext hdbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(hdbContext)
        {
            _hdbContext = hdbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUsingUserManagerAsync(AppUser user, string password)
        {
            //Save New User to Database
            return await _userManager.CreateAsync(user, password);
        }
    }
}