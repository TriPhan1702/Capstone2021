using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class PromotionalCodeRepository : RepositoryBase<PromotionalCode>, IPromotionalCodeRepository
    {
        public PromotionalCodeRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}