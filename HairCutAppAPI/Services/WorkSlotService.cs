using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class WorkSlotService : IWorkSlotService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public WorkSlotService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ActionResult<ICollection<GetWorkSlotResponseDTO>>> FindWorkSlotsOfDay(FindWorkSlotsOfDayDTO findWorkSlotsOfDayDTO)
        {
            var date = DateTime.ParseExact(findWorkSlotsOfDayDTO.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            var slots = await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws =>
                ws.StaffId == findWorkSlotsOfDayDTO.StaffId && ws.Date.DayOfYear == date.DayOfYear);
            if (slots is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "WorkSlots not found");
            }

            return slots.Select(ws => ws.ToGetWorkSlotResponseDTO()).ToList();
        }

        public async Task<ActionResult<GetWorkSlotResponseDTO>> FindWorkSlot(GetWorkSlotDTO getWorkSlotDTO)
        {
            var date = DateTime.ParseExact(getWorkSlotDTO.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            
            //Get Work slot with the same staff, slot of day and date
            var slot = await _repositoryWrapper.WorkSlot.FindSingleByConditionAsync(ws =>
                ws.StaffId == getWorkSlotDTO.StaffId && ws.SlotOfDayId == getWorkSlotDTO.SlotOfDayId &&
                ws.Date.DayOfYear == date.DayOfYear);
            if (slot is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Slot not found"); 
            }
            return slot.ToGetWorkSlotResponseDTO();
        }

        public async Task<ActionResult<int>> AddAvailableWorkSlot(AddWorkSlotDTO addWorkSlotDTO)
        {
            var date = DateTime.ParseExact(addWorkSlotDTO.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            
            //Check if staff exists
            await CheckStaff(addWorkSlotDTO.StaffId);
            //Check if slot of day exists
            await CheckSlotOfDay(addWorkSlotDTO.SlotOfDayId);
            //Check if work slot already exists
            await CheckWorkSlot(addWorkSlotDTO.StaffId, addWorkSlotDTO.SlotOfDayId, date);
            //Check if the inputted date is valid
            CheckDate(date);

            //Add work slot
            var newWorkSlot = addWorkSlotDTO.ToWorkSlot();
            var result = await _repositoryWrapper.WorkSlot.CreateAsync(newWorkSlot);
            return result.Id;
        }

        public async Task<ActionResult<UpdateWorkSlotDTO>> UpdateWorkSlot(UpdateWorkSlotDTO updateWorkSlotDTO)
        {
            //Get Work slot from Id
            var workSlot = await _repositoryWrapper.WorkSlot.FindSingleByConditionAsync(ws => ws.Id == updateWorkSlotDTO.Id);
            //Check if work slot exists
            if (workSlot == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Work slot doesn't exist"); 
            }
            //Check if status is the same
            if (updateWorkSlotDTO.Status.ToLower() == workSlot.Status)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "The new status is the same as the old one"); 
            }

            //Check if slot is already taken
            if (workSlot.Status == GlobalVariables.WorkSlotStatuses[2])
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Cannot change an already taken slot"); 
            }
            
            //Can't manually change workslot status to taken
            if (updateWorkSlotDTO.Status == GlobalVariables.WorkSlotStatuses[2])
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Cannot change an already taken slot"); 
            }

            //Check status is a valid status
            if (!GlobalVariables.WorkSlotStatuses.Contains(updateWorkSlotDTO.Status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Work SLot Status invalid, must be: available, not available");
            }

            workSlot.Status = updateWorkSlotDTO.Status.ToLower();
            return (await _repositoryWrapper.WorkSlot.UpdateAsync(workSlot, workSlot.Id)).ToUpdateWorkSlotDTO();
        }

        #region private functions
        /// <summary>
        /// Check if inputted date is valid, can be a day before and can be more than 2 weeks in the future
        /// </summary>
        private void CheckDate(DateTime date)
        {
            var cultureInfo = new CultureInfo("vi_VN");
            var calendar = cultureInfo.Calendar;

            //Get Now time
            var now = DateTime.Today;
            
            //Get the Week of now
            var nowWeekOfYear = calendar.GetWeekOfYear(now, cultureInfo.DateTimeFormat.CalendarWeekRule,
                cultureInfo.DateTimeFormat.FirstDayOfWeek);
            //Get the Week of inputted date
            var dateWeekOfYear = calendar.GetWeekOfYear(date, cultureInfo.DateTimeFormat.CalendarWeekRule,
                cultureInfo.DateTimeFormat.FirstDayOfWeek);
            
            //If Date is before or is current date or more than 2 weeks in the future
            if (date.DayOfYear <= now.DayOfYear)
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Date is before current date"); 
            
            if (DateTime.Compare(date, now) <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, @"Date is too far in the future(More than 2 weeks)"); 
            }
        }

        private async Task CheckWorkSlot(int id)
        {
            var workSlot = await _repositoryWrapper.WorkSlot.FindSingleByConditionAsync(ws => ws.Id == id);
            if (workSlot is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Work slot doesn't exist"); 
            }
        }

        /// <summary>
        /// Check if the same work slot already exists
        /// </summary>
        private async Task CheckWorkSlot(int staffId, int slotOfDayId, DateTime date)
        {
            var workSlot = await _repositoryWrapper.WorkSlot.FindSingleByConditionAsync(ws =>
                ws.StaffId == staffId &&
                ws.SlotOfDayId == slotOfDayId &&
                ws.Date == date);
            //If the same work slot already exists
            if (workSlot !=null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "WorkSlot already exists"); 
            }
        }

        /// <summary>
        /// Check if staff exists
        /// </summary>
        private async Task CheckStaff(int staffId)
        {
            var staff = await _repositoryWrapper.Staff.FindSingleByConditionAsync(s => s.Id == staffId);

            if (staff is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Staff doesn't exist"); 
            }
        }
        
        /// <summary>
        /// Check if slot of day exists
        /// </summary>
        private async Task CheckSlotOfDay(int slotOfDayId)
        {
            var slot = await _repositoryWrapper.SlotOfDay.FindSingleByConditionAsync(sod => sod.Id == slotOfDayId);

            if (slot is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Staff doesn't exist"); 
            }
        }

        #endregion 
    }
}