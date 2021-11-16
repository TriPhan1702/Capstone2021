using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Notification;

namespace HairCutAppAPI.Services
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IPushNotification _pushNotification;

        public BackgroundJobService(IRepositoryWrapper repositoryWrapper, IPushNotification pushNotification)
        {
            _repositoryWrapper = repositoryWrapper;
            _pushNotification = pushNotification;
        }

        /// <summary>
        /// BACKGROUND JOB: Check if there are pending appointments that has passed the time without approval
        /// </summary>
        public async Task CheckAndUpdatePendingAppointmentJob()
        {
            //Get list of pending assignment from database
            var pendingAppointments = (await _repositoryWrapper.Appointment.FindByConditionAsync(appointment =>
                appointment.Status == GlobalVariables.PendingAppointmentStatus && DateTime.Now.AddMinutes(GlobalVariables.TimeToConfirmAppointmentInAdvanced) >= appointment.StartDate)).ToList();

            if (pendingAppointments.Any())
            {
                var appointmentIds = pendingAppointments.Select(appointment => appointment.Id);
                var workslots =
                    await _repositoryWrapper.WorkSlot.FindByConditionAsyncWithInclude(slot =>
                        appointmentIds.Contains(slot.AppointmentId.Value), slot => slot.SlotOfDay);
                
                //Change status of all appointments to canceled
                foreach (var appointment in pendingAppointments)
                {
                    appointment.Status = GlobalVariables.CanceledAppointmentStatus;
                    appointment.LastUpdated = DateTime.Now;
                    await _repositoryWrapper.Appointment.UpdateAsyncWithoutSave(appointment, appointment.Id);
                }

                foreach (var slot in workslots)
                {
                    //If lot is still more than TimeToCreateAppointmentInAdvanced(default 2 hours) away, turn to available
                    if (slot.Date.Add(slot.SlotOfDay.StartTime).AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced) > DateTime.Now)
                    {
                        slot.Status = GlobalVariables.AvailableWorkSlotStatus;
                        
                    }
                    //If lot is still less than TimeToCreateAppointmentInAdvanced(default 2 hours) away, turn to not available available
                    else
                    {
                        slot.Status = GlobalVariables.NotAvailableWorkSlotStatus;
                    }
                    slot.AppointmentId = null;
                    await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(slot, slot.Id);
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

        /// <summary>
        /// BACKGROUND JOB: Check if there are approved appointments that passed start time and need to be set to ongoing appointment
        /// </summary>
        public async Task CheckAndUpdateApprovedAppointments()
        {
            //Get all appointments with approved status
            var approvedAppointments = (await _repositoryWrapper.Appointment.FindByConditionAsync(appointment =>
                appointment.Status == GlobalVariables.ApprovedAppointmentStatus && 
                appointment.StartDate <= DateTime.Now && 
                DateTime.Now < appointment.EndDate.AddMinutes(GlobalVariables.TimeToFinishAppointmentInAdvanced))).ToList();
            //If there are
            if (approvedAppointments.Any())
            {
                foreach (var appointment in approvedAppointments)
                {
                    appointment.Status = GlobalVariables.OnGoingAppointmentStatus;
                    appointment.LastUpdated = DateTime.Now;
                    await _repositoryWrapper.Appointment.UpdateAsyncWithoutSave(appointment, appointment.Id);
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
                    //TODO: Log failure to update appointment status
                }
            }
        }

        /// <summary>
        /// BACKGROUND JOB: Check if there are ongoing appointments that went passed time to finish
        /// </summary>
        public async Task CheckAndUpdateOngoingAppointments()
        {
            //Get all appointments with ongoing status
            var ongoingAppointments = (await _repositoryWrapper.Appointment.FindByConditionAsync(appointment =>
                appointment.Status == GlobalVariables.OnGoingAppointmentStatus && DateTime.Now >= appointment.EndDate.AddMinutes(GlobalVariables.TimeToFinishAppointmentInAdvanced))).ToList();
            
            //If there are
            if (ongoingAppointments.Any())
            {
                //TODO Send notification to staff and manager
            }
        }

        public async Task CheckAndUpdateInActivePromotionalCodes()
        {
            var codes = (await _repositoryWrapper.PromotionalCode.FindByConditionAsync(code =>
                code.Status == GlobalVariables.InActiveArticleStatus &&
                DateTime.Now >= code.StartDate && DateTime.Now < code.ExpirationDate)).ToList();

            if (codes.Any())
            {
                foreach (var code in codes)
                {
                    code.Status = GlobalVariables.ActivePromotionalCodeStatus;
                    code.LastUpdate = DateTime.Now;
                    await _repositoryWrapper.PromotionalCode.UpdateAsyncWithoutSave(code, code.Id);
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
                    //TODO: Log failure to update code status
                }
            }
        }
        
        /// <summary>
        /// BACKGROUND JOB: Check active codes if it has passed expirationdate
        /// </summary>
        public async Task CheckAndUpdateActivePromotionalCodes()
        {
            var codes = (await _repositoryWrapper.PromotionalCode.FindByConditionAsync(code =>
                code.Status == GlobalVariables.ActivePromotionalCodeStatus &&
                DateTime.Now >= code.ExpirationDate)).ToList();

            if (codes.Any())
            {
                foreach (var code in codes)
                {
                    code.Status = GlobalVariables.InActivePromotionalCodeStatus;
                    code.LastUpdate = DateTime.Now;
                    await _repositoryWrapper.PromotionalCode.UpdateAsyncWithoutSave(code, code.Id);
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
                    //TODO: Log failure to update code status
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

        public async Task SendNotifications()
        {
            //Get notifications
            var notifications = (await _repositoryWrapper.Notification.FindByConditionAsync(notification =>
                //That has pending status
                notification.Status.ToLower() == GlobalVariables.PendingNotificationStatus &&
                //That doesn't have delivery date(instant), or has went passed delivery date
                (notification.DeliveryDate == null || DateTime.Now >= notification.DeliveryDate))).ToList();

            if (notifications.Any())
            {
                //Get unique users ids
                var userIds = notifications.Select(notification => notification.UserId).ToHashSet();

                var users = new List<AppUser>();
                foreach (var userId in userIds)
                {
                    //Get users with their Devices
                    users = (await _repositoryWrapper.User.FindByConditionAsyncWithInclude(
                        user => userIds.Contains(userId), user => user.Devices)).ToList();
                }

                foreach (var notification in notifications)
                {
                    var user = users.FirstOrDefault(appUser => appUser.Id == notification.UserId);
                    if (user is null || user.Devices is null || !user.Devices.Any())
                    {
                        notification.Status = GlobalVariables.CanceledAppointmentStatus;
                    }
                    else
                    {
                        foreach (var device in user.Devices)
                        {
                            _pushNotification.Push(device.DeviceToken, notification.Title, notification.Detail,"AppointmentDetail",new {appointmentID = notification.AppointmentId});
                            notification.Status = GlobalVariables.DeliveredNotificationStatus;
                        }
                    }
                    notification.LastUpdate = DateTime.Now;
                    await _repositoryWrapper.Notification.UpdateAsyncWithoutSave(notification, notification.Id);
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
                //TODO: Log Failure
            }
        }
    }
}