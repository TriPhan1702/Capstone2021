using System;
using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Services
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BackgroundJobService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// BACKGROUND JOB: Check if there are pending appointments that has passed the time without approval
        /// </summary>
        public async Task CheckAndUpdatePendingAppointmentJob()
        {
            //Get list of pending assignment from database
            var pendingAppointments = (await _repositoryWrapper.Appointment.FindByConditionAsync(appointment =>
                appointment.Status == GlobalVariables.PendingAppointmentStatus && appointment.StartDate.AddMinutes(GlobalVariables.TimeToConfirmAppointmentInAdvanced) <= DateTime.Now)).ToList();

            if (pendingAppointments.Any())
            {
                //Change status of all appointments to canceled
                foreach (var appointment in pendingAppointments)
                {
                    appointment.Status = GlobalVariables.CanceledAppointmentStatus;
                    Console.WriteLine(appointment.Status);
                    await _repositoryWrapper.Appointment.UpdateAsyncWithoutSave(appointment, appointment.Id);
                }
                
                try
                {
                    //Save all changes above to database 
                    await _repositoryWrapper.SaveAllAsync();
                    
                    //TODO: Send cancel notification
                }
                catch (Exception e)
                {
                    //clear pending changes if fail
                    _repositoryWrapper.DeleteChanges();
                    //TODO: Log failure to update appointment status
                }
            }
        }

        public async Task CheckAndUpdateActiveWorkSlotJob()
        {
            //Get list of available work slots
            var activeWorkSlots = (await _repositoryWrapper.WorkSlot.GetAvailableWorkSlotsWithSlotOfDay()).ToList();

            if (activeWorkSlots.Any())
            {
                foreach (var slot in activeWorkSlots)
                {
                    var date = slot.Date.Add(slot.SlotOfDay.StartTime);
                    if (date.AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced) <= DateTime.Now)
                    {
                        slot.Status = GlobalVariables.NotAvailableWorkSlotStatus;
                        await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(slot, slot.Id);
                    }
                }
                
                try
                {
                    //Save all changes above to database 
                    await _repositoryWrapper.SaveAllAsync();
                }
                catch (Exception e)
                {
                    //clear pending changes if fail
                    _repositoryWrapper.DeleteChanges();
                    //TODO: Log failure to update work slot
                }
            }
        }
    }
}