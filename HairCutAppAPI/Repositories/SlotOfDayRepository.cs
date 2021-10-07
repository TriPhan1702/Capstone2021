using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class SlotOfDayRepository : RepositoryBase<SlotOfDay>, ISlotOfDayRepository
    {
        public SlotOfDayRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}