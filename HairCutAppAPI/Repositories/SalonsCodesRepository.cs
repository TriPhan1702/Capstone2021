using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class SalonsCodesRepository : RepositoryBase<SalonsCodes>, ISalonsCodesRepository
    {
        public SalonsCodesRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}