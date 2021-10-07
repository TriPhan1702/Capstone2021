using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class CrewRepository : RepositoryBase<Crew>, ICrewRepository
    {
        public CrewRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}