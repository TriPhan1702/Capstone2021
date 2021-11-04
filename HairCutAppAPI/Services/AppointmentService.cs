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
using HairCutAppAPI.Utilities.ImageUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public AppointmentService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        /// <summary>
        /// Debug
        /// </summary>
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppAppointments()
        {
            var appointments = await _repositoryWrapper.Appointment.FindAllAsync();
            return new CustomHttpCodeResponse(200,"", appointments);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllAppointmentStatuses()
        {
            return new CustomHttpCodeResponse(200,"", GlobalVariables.AppointmentStatuses.ToList());
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
                    var unavailableSlots2 =
                        chosenSlotsOfDayIds.Except(chosenWorkSlots.Select(s => s.SlotOfDayId).ToList());
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"The Following slots are not available: " + string.Join(", ", unavailableSlots) + " The Following slots are not available: " + string.Join(", ", unavailableSlots2));
                }
                
                //If all chosen Work Slot are valid, change then status of each workslot to taken
                foreach (var workSlot in chosenWorkSlots)
                {
                    //Change Status to Taken
                    workSlot.Status = GlobalVariables.TakenWorkSlotStatus;
                    await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(workSlot, workSlot.Id);
                }
            }
            
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
                WorkSlots = chosenWorkSlots,
                AppointmentDetails = new List<AppointmentDetail>()
            };

            foreach (var detail in combo.ComboDetails)
            {
                newAppointment.AppointmentDetails.Add(new AppointmentDetail()
                {
                    Price = detail.Service.Price,
                    ServiceId = detail.ServiceId,
                });
            }

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
        
        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetAppointments(CustomerAdvancedGetAppointmentDTO dto)
        {
            var currentUserId = GetCurrentUserId();
            
            if (!string.IsNullOrWhiteSpace(dto.SortBy) && !CustomerAdvancedGetAppointmentDTO.OrderingParams.Contains(dto.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", CustomerAdvancedGetAppointmentDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Appointment.AdvancedGetAppointments(dto.ToAdvancedGetAppointmentsResponseDTO(currentUserId));
            return new CustomHttpCodeResponse(200, "" , result);
        }

        public async Task<CustomHttpCodeResponse> AssignStaff(AssignStaffDTO assignStaffDTO)
        {
            var currentUserId = GetCurrentUserId();
            var currentManager = await 
                _repositoryWrapper.Staff.FindSingleByConditionAsync(staff => staff.UserId == currentUserId);
            if (currentManager is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Manager with User Id{currentUserId} not found");
            }
            
            var now = DateTime.Now;
            //If assign list is empty
            if (!assignStaffDTO.StaffDetailDTOs.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Appointment with id {assignStaffDTO.AppointmentId} not found");
            }
            
            //Get appointment with its detail 
            var appointment = await _repositoryWrapper.Appointment.GetAppointmentWithDetail(assignStaffDTO.AppointmentId);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Appointment with id {assignStaffDTO.AppointmentId} not found");
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
            
            if (!staffs.Select(staff => staff.SalonId).Contains(currentManager.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Current Manager is not form Salon with Id {appointment.SalonId}");
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
            
            //TODO: test this
            // //Get List of unique staff ids from list of work slots
            // var staffListFromWorkSlot = workSlots.Select(slot => slot.StaffId).ToHashSet();
            // if (appointment.ChosenStaffId != null)
            // {
            //     staffListFromWorkSlot.RemoveWhere(i => i == appointment.ChosenStaffId);
            // }
            // //Check if remaining staff is available
            // foreach (var staffId in staffListFromWorkSlot)
            // {
            //     if (workSlots.Count(slot => slot.StaffId == staffId) != slotsOfDayIds.Count)
            //     {
            //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Staff with Id{staffId} is not available in all of the work slots that of the appointment");
            //     }
            // }
            
            //If every work slot is valid, change all of their status to taken
            foreach (var workSlot in workSlots)
            {
                //If appointment is the same day as today
                //If a work slot is less than 1 hour away, abort
                if (appointment.StartDate.DayOfYear == now.DayOfYear && workSlot.Date.Add(workSlot.SlotOfDay.StartTime).AddMinutes(GlobalVariables.TimeToConfirmAppointmentInAdvanced) >= now )
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Appointment is less than {GlobalVariables.TimeToConfirmAppointmentInAdvanced} minutes away, it can not be confirmed");
                }
                //Change the work slot's status
                workSlot.Status = GlobalVariables.TakenWorkSlotStatus;
                //Change work slot's appointment
                workSlot.AppointmentId = appointment.Id;
                //Pend Changes
                await _repositoryWrapper.WorkSlot.UpdateAsyncWithoutSave(workSlot, workSlot.Id);
            }
            
            //Prepare list of AppointmentDetail
            foreach (var detail in assignStaffDTO.StaffDetailDTOs)
            {
                appointment.AppointmentDetails
                        .First(appointmentDetail => appointmentDetail.ServiceId == detail.ServiceId).StaffId = detail.StaffId;
            }
            
            //Change appointment status to approved
            appointment.Status = GlobalVariables.ApprovedAppointmentStatus;
            appointment.LastUpdated = DateTime.Now;
            
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

        public async Task<ActionResult<CustomHttpCodeResponse>> FinishAppointment(FinishAppointmentDTO dto)
        {
            //Get appointment from database
            var appointment = await _repositoryWrapper.Appointment.FindSingleByConditionAsync(app => app.Id == dto.Id);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Appointment with Id {dto.Id} not found");
            }

            //Check if appointment is ongoing, if not, abort
            if (appointment.Status != GlobalVariables.OnGoingAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Appointment has to have {GlobalVariables.OnGoingAppointmentStatus} Status");
            }

            //Upload image
            var imageUploadResult = await _photoService.AppPhotoAsync(dto.Image);
            //If there's error
            if (imageUploadResult.Error != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
            }
            
            //Change Appointment
            appointment.Status = GlobalVariables.CompleteAppointmentStatus;
            appointment.Note = dto.Note;
            appointment.ImageUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            appointment.LastUpdated = DateTime.Now;

            var result = await _repositoryWrapper.Appointment.UpdateAsync(appointment, appointment.Id);
            
            //TODO:Send notifications
            
            return new CustomHttpCodeResponse(200,"Appointment is completed", true);
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