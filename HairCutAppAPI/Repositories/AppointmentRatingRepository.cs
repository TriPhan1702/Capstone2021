using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class AppointmentRatingRepository : RepositoryBase<AppointmentRating>, IAppointmentRatingRepository
    {
        public AppointmentRatingRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}