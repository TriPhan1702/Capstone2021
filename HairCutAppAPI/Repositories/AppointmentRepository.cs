using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly HDBContext _hdbContext;

        public AppointmentRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<Appointment> GetLastedAppointmentOfCustomer(int customerId)
        {
            return await _hdbContext.Appointments.Include(a=>a.AppointmentDetail).Include(a=>a.Customer).Include(a=>a.Salon).OrderByDescending(a => a.CreatedDate)
                .FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }

        public async Task<Appointment> GetAppointmentWithDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(a => a.AppointmentDetail)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
    }
}