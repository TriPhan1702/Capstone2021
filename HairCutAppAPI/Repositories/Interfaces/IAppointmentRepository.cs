using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<Appointment> GetAppointmentOfCustomer(int customerId);
        Task<Appointment> GetAllAppointmentDetail(int appointmentId);
        Task<Appointment> GetAppointmentWithDetail(int appointmentId);
        Task<PagedList<AdvancedGetAppointmentsResponseDTO>> AdvancedGetAppointments(AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO);
    }
}