using System;
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
            if (chosenDate.Add(startSlotOfDay.StartTime) < now.AddHours(GlobalVariables.TimeToCreateAppointmentInAdvanced))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Chosen date has to be at least 2 hours away from now");
            }
            
            //Check if Salon exists
            if (!await SalonExists(createAppointmentDTO.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with Id {createAppointmentDTO.SalonId} doesn't exist");
            }

            AppUser stylistUser = null;
            //If user has already chosen a stylist
            if (createAppointmentDTO.StylistId >= 0)
            {
                //Check if stylist exists
                stylistUser= await _repositoryWrapper.User.FindSingleByConditionAsync(c => c.Id == createAppointmentDTO.StylistId);
                if (!await _repositoryWrapper.User.CheckRole(stylistUser.Email, GlobalVariables.StylistRole))
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Stylist with Id {createAppointmentDTO.StylistId} doesn't exist");
                }
                
                //Get all work slot that has the right SLotOfDayId, StaffId(Stylist's Id), of the correct date and is available
                var chosenWorkSlots = await
                    _repositoryWrapper.WorkSlot.FindByConditionAsync(slot =>
                        chosenSlotsOfDayIds.Contains(slot.SlotOfDayId) &&
                        slot.StaffId == createAppointmentDTO.StylistId &&
                        slot.Date == chosenDate && 
                        slot.Status == GlobalVariables.WorkSlotStatuses[0]) as List<WorkSlot>;

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
                
                //If all chosen Work Slot are valid, change then status of each workslot to available
                foreach (var workSlot in chosenWorkSlots)
                {
                    //Change Status to Taken
                    workSlot.Status = GlobalVariables.WorkSlotStatuses[2];
                    await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(workSlot, workSlot.Id);
                }
            }
            
            //Prepare new list of appointment detail
            var newAppointmentDetails = new List<AppointmentDetail>();
            var staffId = -1;
            if (stylistUser != null)
            {
                staffId = stylistUser.Id;
            }
            foreach (var comboDetail in combo.ComboDetails)
            {
                
                newAppointmentDetails.Add(new AppointmentDetail()
                {
                    ServiceId = comboDetail.ServiceId,
                    Price = comboDetail.Service.Price,
                    StaffId = staffId,
                });
            }
            
            //Prepare new appointment
            var newAppointment = new Appointment()
            {
                SalonId = createAppointmentDTO.SalonId,
                CustomerId = customerId,
                Status = GlobalVariables.NewAppointmentStatus,
                AppointmentDetails = newAppointmentDetails,
                StartDate = chosenDate.Add(startSlotOfDay.StartTime),
                EndDate = chosenDate.Add(endSlotOfDay.EndTime),
                CreatedDate = now,
                LastUpdated = now,
                ComboId = combo.Id,
                PaidAmount = 0,
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
            int? stylistUserId = null;
            string stylistName = null;
            if (stylistUser != null)
            {
                stylistUserId = stylistUser.Id;
                var stylistAsStaff =await _repositoryWrapper.Staff.FindSingleByConditionAsync(s => s.UserId == stylistUserId);
                stylistName = stylistAsStaff.FullName;
            }

            return new CustomHttpCodeResponse(200,"Appointment Created",createdAppointment.ToCreateAppointmentResponseDTO(price, stylistUserId, stylistName)); 
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
                var workSlots = await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws=>slotsOfDayIds.Contains(ws.SlotOfDayId) && staffIds.Contains(ws.StaffId));

                var now = DateTime.Now;
                foreach (var slot in workSlots)
                {
                    //If this work slot is less than TimeToCreateAppointmentInAdvanced(Default 2 hours) away, change status of that slot to not available, else set available
                    slot.Status = appointment.StartDate <= now.AddHours(GlobalVariables.TimeToCreateAppointmentInAdvanced) ? GlobalVariables.NotAvailableWorkSlotStatus : GlobalVariables.AvailableWorkSlotStatus;

                    //Pend change
                    await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(slot, slot.Id);
                }
            }
            
            //Get WorkSlots associated with the appointment
            appointment.Status = GlobalVariables.CanceledAppointmentStatus;
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
        
        // public async Task<CustomHttpCodeResponse> AssignCrew(AssignCrewDTO assignCrewDTO)
        // {
        //     var appointment = await _repositoryWrapper.Appointment.GetAppointmentWithDetailAndCrewDetail(assignCrewDTO.AppointmentId);
        //     if (appointment is null)
        //     {
        //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment with id {assignCrewDTO.AppointmentId} not found");
        //     }
        //
        //     //Check if appointment has pending status
        //     if (appointment.Status != GlobalVariables.PendingAppointmentStatus)
        //     {
        //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment is not pending ");
        //     }
        //
        //     //If appointment hasn't had a crew yet, create a new crew
        //     if (appointment.AppointmentDetails.CrewId is null)
        //     {
        //         appointment.AppointmentDetails.Crew = new Crew
        //         {
        //             CreatedDate = DateTime.Now, LastUpdated = DateTime.Now, CrewDetails = new List<CrewDetail>()
        //         };
        //     }
        //     
        //     //If appointment already has a crew, check for duplicate staffs
        //     else
        //     {
        //         var duplicateStaffs =
        //             appointment.AppointmentDetails.Crew.CrewDetails.Where(crewDetail => assignCrewDTO.StaffIds.Contains(crewDetail.StaffId)).ToList();
        //         //If there's Duplicate, remove that staff id from dto
        //         if (duplicateStaffs.Any())
        //         {
        //             foreach (var staff in duplicateStaffs)
        //             {
        //                 assignCrewDTO.StaffIds.Remove(staff.StaffId);
        //             }
        //         }
        //     }
        //     
        //     //Get All Staff from database that has valid id and is from the same salon as the appointment
        //     var staffs = await _repositoryWrapper.Staff.FindByConditionAsync(staff =>
        //         assignCrewDTO.StaffIds.Contains(staff.Id) && staff.SalonId == appointment.SalonId);
        //     if (staffs is null)
        //     {
        //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"No Staff is found");
        //     }
        //     //If the count is not the same, then some staff doesn't exist or not from the same salon
        //     if ( staffs.Count() != assignCrewDTO.StaffIds.Count)
        //     {
        //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Some Staff is not found or not from the same salon");
        //     }
        //
        //     //Pend Changes to appointment
        //     foreach (var staffId in assignCrewDTO.StaffIds)
        //     {
        //         //Change appointment status
        //         appointment.Status = GlobalVariables.ApprovedAppointmentStatus;
        //         //Add new staff to the crew
        //         appointment.AppointmentDetails.Crew.CrewDetails.Add(new CrewDetail(){CrewId = appointment.AppointmentDetails.Crew.Id, StaffId = staffId});
        //     }
        //
        //     //Save to Database
        //     await _repositoryWrapper.AppointmentDetail.UpdateAsync(appointment.AppointmentDetails, appointment.AppointmentDetails.Id);
        //     var appointmentDetail= await _repositoryWrapper.AppointmentDetail.GetAppointmentDetailWithCrew(assignCrewDTO.AppointmentId);
        //     
        //     return new CustomHttpCodeResponse(200,"Crew Assigned", new AssignCrewResponseDTO()
        //     {
        //         AppointmentId = appointmentDetail.AppointmentId,
        //         StaffIds = appointmentDetail.Crew.CrewDetails.Select(cd=>cd.StaffId).ToList()
        //     }); 
        // }

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

        #endregion private functions
    }
}