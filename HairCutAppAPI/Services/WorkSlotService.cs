using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
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

        public async Task<ActionResult<GetWorkSlotResponseDTO>> GetWorkSlot(GetWorkSlotDTO getWorkSlotDTO)
        {
            var slot = await _repositoryWrapper.WorkSlot.FindSingleByConditionAsync(ws =>
                ws.StaffId == getWorkSlotDTO.StaffId && ws.SlotOfDayId == getWorkSlotDTO.SlotOfDayId &&
                ws.Date.DayOfYear == getWorkSlotDTO.Date.DayOfYear);
            if (slot is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Slot not found"); 
            }
            return slot.ToGetWorkSlotResponseDTO();
        }

        public async Task<ActionResult<int>> AddAvailableWorkSlot(AddWorkSlotDTO addWorkSlotDTO)
        {
            //Check if staff exists
            await CheckStaff(addWorkSlotDTO.StaffId);
            //Check if slot of day exists
            await CheckSlotOfDay(addWorkSlotDTO.SlotOfDayId);
            //Check if work slot already exists
            await CheckWorkSlot(addWorkSlotDTO);
            //Check if the inputted date is valid
            CheckDate(addWorkSlotDTO.Date);

            //Add work slot
            var newWorkSlot = addWorkSlotDTO.ToWorkSlot();
            var result = await _repositoryWrapper.WorkSlot.CreateAsync(newWorkSlot);
            return result.Id;
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

        /// <summary>
        /// Check if the same work slot already exists
        /// </summary>
        private async Task CheckWorkSlot(AddWorkSlotDTO addWorkSlotDTO)
        {
            var workSlot = await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws =>
                ws.StaffId == addWorkSlotDTO.StaffId &&
                ws.SlotOfDayId == addWorkSlotDTO.SlotOfDayId &&
                ws.Date == addWorkSlotDTO.Date);
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