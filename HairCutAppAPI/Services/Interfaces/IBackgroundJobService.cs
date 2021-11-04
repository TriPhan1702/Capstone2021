using System.Threading.Tasks;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IBackgroundJobService
    {
        Task CheckAndUpdatePendingAppointmentJob();
        Task CheckAndUpdateActiveWorkSlotJob();

        /// <summary>
        /// BACKGROUND JOB: Check if there are approved appointments that passed start time and need to be set to ongoing appointment
        /// </summary>
        Task CheckAndUpdateApprovedAppointments();
        
        /// <summary>
        /// BACKGROUND JOB: Check if there are ongoing appointments that went passed time to finish
        /// </summary>
        Task CheckAndUpdateOngoingAppointments();

        Task CheckAndUpdateInActivePromotionalCodes();
        Task CheckAndUpdateActivePromotionalCodes();
    }
}