using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class AppointmentDetailRepository : RepositoryBase<AppointmentDetail>, IAppointmentDetailRepository
    {
        public AppointmentDetailRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}