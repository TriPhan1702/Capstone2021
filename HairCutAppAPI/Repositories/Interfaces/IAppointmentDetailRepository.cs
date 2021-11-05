using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IAppointmentDetailRepository : IRepositoryBase<AppointmentDetail>
    {
        Task<IEnumerable<AppointmentDetail>> GetAppointmentDetailsWithStaff(int appointmentId);
        Task<IEnumerable<AppointmentDetail>> GetAppointmentDetailWithStaffAndService(int appointmentId);
        Task<ICollection<int>> GetUniqueStaffIds(int appointmentId);
    }
}