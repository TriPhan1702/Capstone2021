using System.Threading.Tasks;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IAppointmentDetailRepository : IRepositoryBase<AppointmentDetail>
    {
        Task<AppointmentDetail> GetAppointmentDetailWithCrew(int appointmentId);
    }
}