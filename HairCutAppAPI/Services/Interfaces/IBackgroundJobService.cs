using System.Threading.Tasks;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IBackgroundJobService
    {
        Task CheckAndUpdatePendingAppointmentJob();
    }
}