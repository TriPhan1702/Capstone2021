using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class WorkSlotRepository : RepositoryBase<WorkSlot>, IWorkSlotRepository
    {
        public WorkSlotRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}