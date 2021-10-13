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
            return await _hdbContext.Appointments.Include(a=>a.AppointmentDetail).Include(a=>a.Customer).Include(a=>a.Salon).OrderByDescending(a => a.CreatedDate)
                .FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }

        public async Task<Appointment> GetAllAppointmentDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(appointment => appointment.Customer)
                .Include(appointment => appointment.Rating)
                .Include(appointment => appointment.Salon)
                .Include(appointment => appointment.AppointmentDetail)
                .ThenInclude(detail => detail.Crew)
                .ThenInclude(c=>c.CrewDetails)
                .ThenInclude(crewDetail => crewDetail.Staff)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }

        public async Task<Appointment> GetAppointmentWithDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(a => a.AppointmentDetail)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
        
        public async Task<Appointment> GetAppointmentWithDetailAndCrewDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(a => a.AppointmentDetail).ThenInclude(ad=>ad.Crew).ThenInclude(c=>c.CrewDetails)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
    }
}