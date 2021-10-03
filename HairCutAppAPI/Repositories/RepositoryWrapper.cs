using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly HDBContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private IUserRepository _user;
        private ICustomerRepository _customer;
        private IStaffRepository _staff;
        private ISalonRepository _salon;
        private IServiceRepository _service;
        private IComboRepository _combo;
        private IReviewRepository _review;
        private readonly UserManager<AppUser> _userManager;

        public RepositoryWrapper(UserManager<AppUser> userManager, HDBContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        //Create concrete repositories if there aren't
        public IUserRepository User => _user ??= new UserRepository(_context, _userManager, _signInManager);
        public ICustomerRepository Customer => _customer ??= new CustomerRepository(_context, _userManager, _signInManager);
        public IStaffRepository Staff => _staff ??= new StaffRepository(_context, _userManager, _signInManager);
        public ISalonRepository Salon => _salon ??= new SalonRepository(_context);
        public IServiceRepository Service => _service ??= new ServiceRepository(_context);
        public IComboRepository Combo => _combo ??= new ComboRepository(_context);
        public IReviewRepository Review => _review ??= new ReviewRepository(_context);

        //For saving multiple changes, if lower than 0 -> no changes
        public async Task<bool> SaveAllAsync()
        { 
            return await _context.SaveChangesAsync() > 0;
        }
        
        public bool HasChanged()
        {
            return _context.ChangeTracker.HasChanges();
        }

        
        public void DeleteChanges()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        
    }
}