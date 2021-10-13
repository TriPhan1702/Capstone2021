using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<Appointment> GetLastedAppointmentOfCustomer(int customerId);
        Task<Appointment> GetAppointmentWithDetail(int appointmentId);
        Task<Appointment> GetAppointmentWithDetailAndCrewDetail(int appointmentId);
    }
}