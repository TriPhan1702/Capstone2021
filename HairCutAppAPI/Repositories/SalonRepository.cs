using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class SalonRepository : RepositoryBase<Salon>, ISalonRepository
    {
        public SalonRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}