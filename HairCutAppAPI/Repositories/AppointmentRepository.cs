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

        public async Task<Appointment> GetAppointmentOfCustomer(int customerId)
        {
            return await _hdbContext.Appointments.Include(a=>a.AppointmentDetails).Include(a=>a.Customer).Include(a=>a.Salon).OrderByDescending(a => a.CreatedDate)
                .FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }

        public async Task<Appointment> GetAllAppointmentDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(appointment => appointment.Customer)
                .Include(appointment => appointment.Rating)
                .Include(appointment => appointment.Salon)
                .Include(appointment => appointment.AppointmentDetails)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }

        public async Task<Appointment> GetAppointmentWithDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(a => a.AppointmentDetails)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
    }
}