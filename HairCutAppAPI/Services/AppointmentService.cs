﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppointmentService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAppointment(CreateAppointmentDTO createAppointmentDTO)
        {
            //Get Current User's Id
            var customerId = GetCurrentUserId();
            
            //Check if Customer exists, check role
            if (! await CheckUserOfRoleExists(customerId, GlobalVariables.CustomerRole))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer  with Id {customerId} doesn't exist");
            }
            
            //Check if this customer already have an active appointment
            var existedAppointment =
                await _repositoryWrapper.Appointment.FindByConditionAsync(a => a.CustomerId == customerId && GlobalVariables.ActiveAppointmentStatuses.Contains(a.Status));
            //If there's such an appointment, abort
            if (existedAppointment != null && existedAppointment.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer with Id {customerId} already has an appointment");
            }
            
            //Convert the chosen date from DTO from string to DateTime
            var chosenDate = DateTime.ParseExact(createAppointmentDTO.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            //Get Now Time
            var now = DateTime.Now;
            
            //Get Combo (with list of ComboDetail and ServiceDetail to use for adding Appointment Detail later) from database
            var combo = await _repositoryWrapper.Combo.GetOneComboWithDetailsAndServiceDetails(createAppointmentDTO.ComboId);
            //Check if Combo exists
            if (combo is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Combo with Id {createAppointmentDTO.ComboId} doesn't exist");
            }
            //Check if Combo is Empty
            if (!combo.ComboDetails.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Can't not order combo with no service");
            }
            
            var chosenSlotsOfDayIds = new List<int>();
            //Get Id list of all the chosen Slots of Day base on the combo's duration
            for (var i = createAppointmentDTO.StartSlotOfDayId; i < createAppointmentDTO.StartSlotOfDayId + combo.Duration; i++)
            {
                chosenSlotsOfDayIds.Add(i);
            }
            
            //Get Slot Of Day from the first to the last WorkSLot to calculate EndTime and compare chosen time with now
            var startSlotOfDay = await 
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod => sod.Id == chosenSlotsOfDayIds.First());
            var endSlotOfDay = await 
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod => sod.Id == chosenSlotsOfDayIds.Last());

            
            //If chosen date less than TimeToCreateAppointmentInAdvanced(Default 2) hours away, abort
            if (chosenDate.Add(startSlotOfDay.StartTime) < now.AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Chosen date has to be at least 2 hours away from now");
            }
            
            //Check if Salon exists
            if (!await SalonExists(createAppointmentDTO.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with Id {createAppointmentDTO.SalonId} doesn't exist");
            }

            Staff chosenStylist = null;
            var chosenWorkSlots = new List<WorkSlot>();
            //If user has already chosen a stylist
            if (createAppointmentDTO.StylistStaffId >= 0)
            {
                //Check if stylist exists
                chosenStylist= await _repositoryWrapper.Staff.FindSingleByConditionAsync(staff => staff.Id == createAppointmentDTO.StylistStaffId);
                if (chosenStylist is null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Stylist with Id {createAppointmentDTO.StylistStaffId} doesn't exist");
                }
                //If this staff is not a stylist
                if (chosenStylist.StaffType != GlobalVariables.StylistRole)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Staff with Id {createAppointmentDTO.StylistStaffId} is not a stylist");
                }
                
                //Get all work slot that has the right SLotOfDayId, StaffId(Stylist's Id), of the correct date and is available
                chosenWorkSlots = await
                    _repositoryWrapper.WorkSlot.FindByConditionAsync(slot =>
                        chosenSlotsOfDayIds.Contains(slot.SlotOfDayId) &&
                        slot.StaffId == createAppointmentDTO.StylistStaffId &&
                        slot.Date.DayOfYear == chosenDate.DayOfYear && 
                        slot.Status == GlobalVariables.AvailableWorkSlotStatus) as List<WorkSlot>;

                //If no available work slot is found
                if (chosenWorkSlots is null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"There's no available work slots for the chosen time");
                }
                
                //If the count of chosenSlots is not the same as chosenSlotsIds, then some slots are not available, abort
                if (chosenWorkSlots.Count != chosenSlotsOfDayIds.Count)
                {
                    var unavailableSlots =
                        chosenWorkSlots.Select(s => s.SlotOfDayId).ToList().Except(chosenSlotsOfDayIds);
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"The Following slots are not available: " + string.Join(", ", unavailableSlots));
                }
                
                //If all chosen Work Slot are valid, change then status of each workslot to taken
                foreach (var workSlot in chosenWorkSlots)
                {
                    //Change Status to Taken
                    workSlot.Status = GlobalVariables.TakenAppointmentStatus;
                    await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(workSlot, workSlot.Id);
                }
            }
            
            // //Prepare new list of appointment detail
            // var newAppointmentDetails = new List<AppointmentDetail>();
            // var staffId = -1;
            // if (stylistUser != null)
            // {
            //     staffId = stylistUser.Id;
            // }
            // foreach (var comboDetail in combo.ComboDetails)
            // {
            //     
            //     newAppointmentDetails.Add(new AppointmentDetail()
            //     {
            //         ServiceId = comboDetail.ServiceId,
            //         Price = comboDetail.Service.Price,
            //         StaffId = staffId,
            //     });
            // }
            
            //Prepare new appointment
            var newAppointment = new Appointment()
            {
                SalonId = createAppointmentDTO.SalonId,
                CustomerId = customerId,
                Status = GlobalVariables.NewAppointmentStatus,
                StartDate = chosenDate.Add(startSlotOfDay.StartTime),
                EndDate = chosenDate.Add(endSlotOfDay.EndTime),
                CreatedDate = now,
                LastUpdated = now,
                ComboId = combo.Id,
                PaidAmount = 0,
                ChosenStaffId = chosenStylist?.Id,
                WorkSlots = chosenWorkSlots
            };

            //Pend create change
            await _repositoryWrapper.Appointment.CreateWithoutSaveAsync(newAppointment);
            
            //Save appointment to database
            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went creating Appointment " + e.Message);
            }
            
            //Get Latest Appointment of customer
            var createdAppointment = await _repositoryWrapper.Appointment.GetAppointmentOfCustomer(customerId);
            var price = await CalculateComboPrice(createAppointmentDTO.ComboId);

            return new CustomHttpCodeResponse(200,"Appointment Created",createdAppointment.ToCreateAppointmentResponseDTO(price, chosenStylist?.Id, chosenStylist?.FullName)); 
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CancelAppointment(int appointmentId)
        {
            
            //Find appointment in database
            var appointment = await  _repositoryWrapper.Appointment.GetAppointmentWithDetail(appointmentId);

            //If appointment not found
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Appointment with Id {appointmentId} doesn't exist");
            }
            
            //Can't cancel already canceled or completed appointments
            if (appointment.Status == GlobalVariables.CanceledAppointmentStatus || appointment.Status == GlobalVariables.CompleteAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Can't cancel already canceled or completed appointments");
            }
            //Get Current User's Id
            var userId = GetCurrentUserId();
            
            //Get User from database
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(u => u.Id == userId);
            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Current User not found");
            }
            // If User is a customer
             if (user.Role.ToLower() == GlobalVariables.CustomerRole.ToLower())
             {
                 //If Customer Id is not the same as appointment's user id, abort
                 if (userId != appointment.CustomerId)
                 {
                     throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Customer Id doesn't match");
                 }
             }

             //Get unique staff Id associated with the appointment
             var staffIds = await 
                 _repositoryWrapper.AppointmentDetail.GetUniqueStaffIds(appointmentId);
             
            //If the appointment already has a crew chosen, change the status of WorkSlots associated with the crew
            if (staffIds!= null && staffIds.Any())
            {
                //If staffId list hasn't had the chosen staff yet, add
                if (appointment.ChosenStaffId!=null && !staffIds.Contains(appointment.ChosenStaffId.Value))
                {
                    staffIds.Add(appointment.ChosenStaffId.Value);
                }
                //Get start SlotOfDay
                var startSlotOfDay = await 
                    _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod =>
                        sod.StartTime == appointment.StartDate.TimeOfDay);
                if (startSlotOfDay is null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Start slot not found");
                }
                //Get end SlotOfDay
                var endSlotOfDay = await 
                    _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod =>
                        sod.EndTime == appointment.EndDate.TimeOfDay);
                if (endSlotOfDay is null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"End slot not found");
                }

                var slotsOfDayIds = new List<int>(){startSlotOfDay.Id};
                //Get list of Slot Of Day associated with the appointment
                for (var i = startSlotOfDay.Id; i <= endSlotOfDay.Id; i++)
                {
                    slotsOfDayIds.Add(i);
                }
            
                //Get list of work slots associated with the staff and slot Of day list
                var workSlots = await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws=>slotsOfDayIds.Contains(ws.SlotOfDayId) && staffIds.Contains(ws.StaffId) && ws.Date.DayOfYear == appointment.StartDate.DayOfYear);

                var now = DateTime.Now;
                foreach (var slot in workSlots)
                {
                    //If this work slot is less than TimeToCreateAppointmentInAdvanced(Default 2 hours) away, change status of that slot to not available, else set available
                    slot.Status = appointment.StartDate <= now.AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced) ? GlobalVariables.NotAvailableWorkSlotStatus : GlobalVariables.AvailableWorkSlotStatus;
                    slot.AppointmentId = null;
                    //Pend change
                    await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(slot, slot.Id);
                }
            }
            
            //Change appointment's status and last update
            appointment.Status = GlobalVariables.CanceledAppointmentStatus;
            appointment.LastUpdated = DateTime.Now;
            
            var result = await _repositoryWrapper.Appointment.UpdateAsyncWithoutSave(appointment, appointment.Id);

            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went canceling Appointment " + e.Message);
            }
            
            return new CustomHttpCodeResponse(200,"", result.ToChangeAppointmentStatusResponseDTO()); 
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentDetail(int appointmentId)
        {
            //Get Current User's Id
            var userId = GetCurrentUserId();
            
            var appointment = await _repositoryWrapper.Appointment.GetAllAppointmentDetail(appointmentId);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Appointment not found");
            }
        
            //If current User is a customer and the id doesn't match with the appointment's customer Id, abort
            if ( await CheckUserOfRoleExists(userId, GlobalVariables.CustomerRole) && appointment.CustomerId != userId)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Current user is not the owner of this appointment");
            }
        
            var combo = await _repositoryWrapper.Combo.GetOneComboWithDetailsAndServiceDetails(appointment.ComboId);
        
            return new CustomHttpCodeResponse(200,"",appointment.ToGetAppointmentDetailResponseDTO(combo));
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetAppointments(AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.SortBy) && !AdvancedGetAppointmentsDTO.OrderingParams.Contains(advancedGetAppointmentsDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetAppointmentsDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Appointment.AdvancedGetAppointments(advancedGetAppointmentsDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }

        public async Task<CustomHttpCodeResponse> AssignStaff(AssignStaffDTO assignStaffDTO)
        {
            var now = DateTime.Now;
            //If assign list is empty
            if (!assignStaffDTO.StaffDetailDTOs.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment with id {assignCrewDTO.AppointmentId} not found");
            }
            
            //Get appointment with its combo's detail 
            var appointment = await _repositoryWrapper.Appointment.GetAppointmentWithComboDetail(assignStaffDTO.AppointmentId);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment with id {assignCrewDTO.AppointmentId} not found");
            }
            
            //Get list of services from appointment's combo
            var services = appointment.Combo.ComboDetails.Select(detail => detail.Service).ToList();
            //If there services that are not in the dto, abort
            if (services.Select(service => service.Id).Except(assignStaffDTO.StaffDetailDTOs.Select(detail => detail.ServiceId)).Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "All of Combo's Service's staff must be filled in");
            }
            if ((assignStaffDTO.StaffDetailDTOs.Select(detail => detail.ServiceId)).Except(services.Select(service => service.Id)).Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Some service are not in the appointment's combo");
            }
        
            //Check if appointment has pending status
            if (appointment.Status != GlobalVariables.PendingAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment is not pending ");
            }
            
            //Get a list of staff ids from dto
            var staffIds = assignStaffDTO.StaffDetailDTOs.Select(detail => detail.StaffId).ToList();
            //If customer has already chosen a stylist, check if that stylist is in the assign list
            if (appointment.ChosenStaffId != null && !staffIds.Contains(appointment.ChosenStaffId.Value))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "The assigned staffs doesn't have the stylist that customer has chosen");
            }
            
            //Get All Staff from database that has valid id and is from the same salon as the appointment
            var staffs = (await _repositoryWrapper.Staff.FindByConditionAsync(staff =>
                staffIds.Contains(staff.Id) && staff.SalonId == appointment.SalonId)).ToList();
            if (staffs is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"No Staff is found");
            }
            
            //If the count is not the same, then some staff doesn't exist or not from the same salon
            if ( staffs.Count != staffIds.Count)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Some Staff is not found or not from the same salon");
            }
            
            //Check if there's staff with invalid role
            foreach (var staff in staffs.Where(staff => staff.StaffType != GlobalVariables.StylistRole && staff.StaffType != GlobalVariables.BeauticianRole))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Staff with id {staff.Id} is not a valid type of staff");
            }
            
            //Get a list of slot of days associated with the appointment
            var slotsOfDayIds = await SlotOfDayIdsFromStartTimeEndTime(appointment);
            
            //Get list of work slots available associated with the staff and slot Of day list in the same day as the appointment
            var workSlots =
                await _repositoryWrapper.WorkSlot.GetAvailableWorkSlotsDetailFromStaffListAndSlotOfDayListAndDate(
                    appointment.StartDate, staffIds, slotsOfDayIds);
            
            if (workSlots is null || !workSlots.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"There is no work slot available");
            }
            if (appointment.ChosenStaffId is null)
            {
                //If every work slot of every staff are available, the count of workSlots should be slotsOfDayIds.Count * staffIds.Count
                if (workSlots.Count != staffIds.Count * slotsOfDayIds.Count)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Some staffs are not available in the appointment's span of time");
                } 
            }
            else
            {
                //If every work slot of every staff are available, the count of workSlots should be slotsOfDayIds.Count * staffIds.Count - slotsOfDayIds.Count, excluding workslot of the chosen stylist
                if (workSlots.Count != (staffIds.Count * slotsOfDayIds.Count) - slotsOfDayIds.Count)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Some staffs are not available in the appointment's span of time");
                } 
            }
            
            //If every work slot is valid, change all of their status to taken
            foreach (var workSlot in workSlots)
            {
                //If appointment is the same day as today
                //If a work slot is less than 1 hour away, abort
                if (appointment.StartDate.DayOfYear == now.DayOfYear && workSlot.Date.Add(workSlot.SlotOfDay.StartTime).AddMinutes(GlobalVariables.TimeToConfirmAppointmentInAdvanced) >= now )
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"WorkSlot {workSlot.Id} is less than {GlobalVariables.TimeToConfirmAppointmentInAdvanced} hours away");
                }
                //Change the work slot's status
                workSlot.Status = GlobalVariables.TakenAppointmentStatus;
                //Change work slot's appointment
                workSlot.AppointmentId = appointment.Id;
                //Pend Changes
                await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(workSlot, workSlot.Id);
            }
        
            //Prepare list of AppointmentDetail
            var appointmentDetails = new List<AppointmentDetail>();
            foreach (var detail in assignStaffDTO.StaffDetailDTOs)
            {
                appointmentDetails.Add(new AppointmentDetail()
                {
                    AppointmentId = appointment.Id,
                    StaffId = detail.StaffId,
                    ServiceId = detail.ServiceId,
                    Price = services.Find(service => service.Id == detail.ServiceId).Price,
                });
            }
            
            //Change appointment status to approved
            appointment.Status = GlobalVariables.ApprovedAppointmentStatus;
            appointment.LastUpdated = DateTime.Now;
            
            appointment.AppointmentDetails = appointmentDetails;
        
            //Save to Database
            await _repositoryWrapper.Appointment.UpdateAsyncWithoutSave(appointment, appointment.Id);
            
            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went assigning staff the appointment " + e.Message);
            }
            
            return new CustomHttpCodeResponse(200,"Crew Assigned"); 
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CheckCustomerHasCompletedAppointment()
        {
            var customerId = GetCurrentUserId();
            var customer =
                _repositoryWrapper.Customer.FindSingleByConditionAsync(customer1 => customer1.User.Id == customerId);
            if (customer is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,$"Customer with user Id {customerId} not found");
            }

            return new CustomHttpCodeResponse(200,"",await _repositoryWrapper.Appointment.AnyAsync(appointment =>
                appointment.CustomerId == customer.Id &&
                appointment.Status == GlobalVariables.CompleteAppointmentStatus)); 
        }

        #region private functions
        
        private int GetCurrentUserId()
        {
            int customerId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return customerId;
        }

        private async Task<bool> SalonExists(int salonId)
        {
            return await _repositoryWrapper.Salon.AnyAsync(s => s.Id == salonId);
        }
        
        private async Task<bool> SlotExists(int startSlotOfDayId)
        {
            return await _repositoryWrapper.SlotOfDay.AnyAsync(s => s.Id == startSlotOfDayId);
        }
        
        private async Task<bool> ComboExists(int comboId)
        {
            return await _repositoryWrapper.Combo.AnyAsync(c => c.Id == comboId);
        }
        
        private async Task<bool> CheckUserOfRoleExists(int userId, string role)
        {
            return await _repositoryWrapper.User.AnyAsync(user => user.Id == userId && user.Role.ToLower() == role.ToLower());
        }

        private async Task CheckSlot(int startSlotOfDayId)
        {
            if (!await SlotExists(startSlotOfDayId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "SlotOfDay with the id {startSlotOfDayId doesn't exist}");
            }
        }
        
        /// <summary>
        /// Calculate the price of a combo base on comboId from its services
        /// </summary>
        private async Task<decimal> CalculateComboPrice(int comboId)
        {
            var comboDetails = await _repositoryWrapper.ComboDetail.FindComboDetailWithService(comboId);
            if (comboDetails is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"ComboDetails not found");
            }

            var price = comboDetails.Sum(comboDetail => comboDetail.Service.Price);
            return price;
        }

        private async Task<List<int>> SlotOfDayIdsFromStartTimeEndTime(Appointment appointment)
        {
            //Get start SlotOfDay
            var startSlotOfDay = await 
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod =>
                    sod.StartTime == appointment.StartDate.TimeOfDay);
            if (startSlotOfDay is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Start slot not found");
            }
            //Get end SlotOfDay
            var endSlotOfDay = await 
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod =>
                    sod.EndTime == appointment.EndDate.TimeOfDay);
            if (endSlotOfDay is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"End slot not found");
            }

            var slotsOfDayIds = new List<int>(){startSlotOfDay.Id};
            //Get list of Slot Of Day associated with the appointment
            for (var i = startSlotOfDay.Id; i <= endSlotOfDay.Id; i++)
            {
                slotsOfDayIds.Add(i);
            }

            return slotsOfDayIds;
        }

        #endregion private functions
    }
}