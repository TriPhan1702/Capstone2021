using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppoinmentDTOs;
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

        public async Task<ActionResult<CreateAppointmentResponseDTO>> CreateAppointment(CreateAppointmentDTO createAppointmentDTO)
        {
            //Get Current customer Id
            var customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Check if Customer exists, check role
            if (! await CheckUserOfRoleExists(customerId, GlobalVariables.CustomerRole))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer  with Id {customerId} doesn't exist");
            }
            
            //Convert the chosen date from DTO from string to DateTime
            var chosenDate = DateTime.ParseExact(createAppointmentDTO.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            //Get Now Time
            var now = DateTime.Now;
            
            //Get Combo from database
            var combo = await _repositoryWrapper.Combo.FindSingleByConditionAsync(c => c.Id == createAppointmentDTO.ComboId);
            //Check if Combo exists
            if (combo is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Combo with Id {createAppointmentDTO.ComboId} doesn't exist");
            }
            
            var chosenSlotsOfDayIds = new List<int>();
            //Get Id list of all the chosen Slots of Day base on the combo's duration
            for (var i = createAppointmentDTO.StartSlotOfDayId; i < createAppointmentDTO.StartSlotOfDayId + combo.Duration; i++)
            {
                chosenSlotsOfDayIds.Add(i);
            }
            
            //Get Slot Of day to the last WorkSLot to calculate EndTime and compare chosen time with now
            var startSlotOfDay = await 
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod => sod.Id == chosenSlotsOfDayIds.First());
            var endSlotOfDay = await 
                _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod => sod.Id == chosenSlotsOfDayIds.Last());

            
            //If chosen date less than 2 hours away, abort
            if (chosenDate.Add(startSlotOfDay.StartTime) < now.AddHours(1))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Chosen date has to be at least 2 hours away from now");
            }
            
            //Check if this customer already have an appointment on the same day
            var existedAppointment =
                await _repositoryWrapper.Appointment.FindSingleByConditionAsync(a => a.CustomerId == customerId && a.StartDate.DayOfYear == chosenDate.DayOfYear);
            //If there's such a appointment, abort
            if (existedAppointment != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer with Id {customerId} already has an appointment on the same date");
            }
            
            //Check if Salon exists
            if (!await SalonExists(createAppointmentDTO.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with Id {createAppointmentDTO.SalonId} doesn't exist");
            }

            AppUser stylist = null;
            //If user has already chosen a stylist
            if (createAppointmentDTO.StylistId >= 0)
            {
                //Check if stylist exists
                stylist= await _repositoryWrapper.User.FindSingleByConditionAsync(c => c.Id == createAppointmentDTO.StylistId);
                if (!await _repositoryWrapper.User.CheckRole(stylist, GlobalVariables.StylistRole))
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
            
            Crew crew = null;
            //If a stylist is chosen, prepare crew
            if (stylist!=null)
            {
                crew = new Crew()
                {
                    CreatedDate = now,
                    LastUpdated = now,
                    CrewDetails = new List<CrewDetail>()
                    {
                        new CrewDetail()
                        {
                            StaffId = createAppointmentDTO.StylistId,
                        }
                    }
                };
            }
            //Prepare new appointment detail
            var newAppointmentDetail = new AppointmentDetail()
            {
                ComboId = createAppointmentDTO.ComboId,
                Crew = crew,
            };
            //Prepare new appointment
            var newAppointment = new Appointment()
            {
                SalonId = createAppointmentDTO.SalonId,
                CustomerId = customerId,
                Status = GlobalVariables.NewAppointmentStatus,
                AppointmentDetail = newAppointmentDetail,
                StartDate = chosenDate.Add(startSlotOfDay.StartTime),
                EndDate = chosenDate.Add(endSlotOfDay.EndTime),
                CreatedDate = now,
                LastUpdated = now,
            };

            //Pend create change
            await _repositoryWrapper.Appointment.CreateWithoutSaveAsync(newAppointment);
            
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
            
            //Get Lasted Appointment of customer
            var createdAppointment = await _repositoryWrapper.Appointment.GetLastedAppointmentOfCustomer(customerId);
            var price = await CalculateComboPrice(createAppointmentDTO.ComboId);
            int? stylistId = null;
            string stylistName = null;
            if (stylist != null)
            {
                stylistId = stylist.Id;
                var stylistAsStaff =await _repositoryWrapper.Staff.FindSingleByConditionAsync(s => s.Id == stylistId);
                stylistName = stylistAsStaff.FullName;
            }

            return createdAppointment.ToCreateAppointmentResponseDTO(price, stylistId, stylistName);
        }

        #region private functions

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
            var user = await _repositoryWrapper.User.FindSingleByConditionAsync(c => c.Id == userId);
            if (user is null)
            {
                return false;
            }

            return await _repositoryWrapper.User.CheckRole(user, role);
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