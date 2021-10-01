using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        private readonly HDBContext _hdbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        
        public StaffRepository(HDBContext hdbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(hdbContext)
        {
            _hdbContext = hdbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
    }
}