using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class CrewDetailRepository : RepositoryBase<CrewDetail>, ICrewDetailRepository
    {
        public CrewDetailRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}