using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        private readonly HDBContext _hdbContext;
        
        public StaffRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<Staff> GetStaffDetail(int userId)
        {
            return await _hdbContext.Staff.Include(staff => staff.User).FirstOrDefaultAsync(staff => staff.UserId == userId);
        }
    }
}