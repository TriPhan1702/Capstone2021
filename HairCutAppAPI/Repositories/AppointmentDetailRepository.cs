using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class AppointmentDetailRepository : RepositoryBase<AppointmentDetail>, IAppointmentDetailRepository
    {
        private readonly HDBContext _hdbContext;

        public AppointmentDetailRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<IEnumerable<AppointmentDetail>> GetAppointmentDetailsWithStaff(int appointmentId)
        {
            return await _hdbContext.AppointmentDetails.Include(a => a.Staff)
                .Where(a => a.AppointmentId == appointmentId).ToListAsync();
        }
    }
}