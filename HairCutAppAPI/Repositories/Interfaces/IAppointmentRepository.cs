using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<Appointment> GetAppointmentOfCustomer(int customerId);
        Task<Appointment> GetAllAppointmentDetail(int appointmentId);
        Task<Appointment> GetAppointmentWithDetail(int appointmentId);
    }
}