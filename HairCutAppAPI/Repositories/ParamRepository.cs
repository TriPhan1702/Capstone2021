using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class ParamRepository : RepositoryBase<Param>, IParamRepository
    {
        public ParamRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}