using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        private readonly HDBContext _hdbContext;
        
        public StaffRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }
    }
}