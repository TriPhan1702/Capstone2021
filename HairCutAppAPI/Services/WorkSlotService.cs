﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class WorkSlotService : IWorkSlotService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkSlotService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
        }
        
        /// <summary>
        /// DEBUG
        /// </summary>
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllWorkSlots()
        {
            var slots = await _repositoryWrapper.WorkSlot.FindAllAsync();
            
            return new CustomHttpCodeResponse(200, "", slots);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> FindWorkSlotsOfTimeSpan(FindWorkSlotsOfTimeSpanDTO findWorkSlotsOfTimeSpanDTO)
        {
            var startDate = DateTime.ParseExact(findWorkSlotsOfTimeSpanDTO.StartDate, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(findWorkSlotsOfTimeSpanDTO.EndDate, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            //if end date is before start date, swap
            if (endDate<startDate)
            {
                var tempDate = startDate;
                startDate = endDate;
                endDate = tempDate;
            }
            var slots = await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws =>
                ws.StaffId == findWorkSlotsOfTimeSpanDTO.StaffId && ws.Date.DayOfYear >= startDate.DayOfYear && ws.Date.DayOfYear <= endDate.DayOfYear);
            if (slots is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "WorkSlots not found");
            }

            return new CustomHttpCodeResponse(200,"",slots.Select(ws => ws.ToGetWorkSlotResponseDTO()).ToList());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> FindWorkSlotsOfDay(FindWorkSlotsOfDayDTO findWorkSlotsOfDayDTO)
        {
            var date = DateTime.ParseExact(findWorkSlotsOfDayDTO.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            var slots = await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws =>
                ws.StaffId == findWorkSlotsOfDayDTO.StaffId && ws.Date.DayOfYear == date.DayOfYear);
            if (slots is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "WorkSlots not found");
            }

            return new CustomHttpCodeResponse(200,"",slots.Select(ws => ws.ToGetWorkSlotResponseDTO()).ToList());
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> FindOwnWorkSlotsOfDay(FindOwnWorkSlotsOfDayDTO dto)
        {
            //Tìm staff
            var currentUserId = GetCurrentUserId();
            var staff = _repositoryWrapper.Staff.FindSingleByConditionAsync(sta =>
                //Có User Id giống
                sta.UserId == currentUserId && 
                //Không phải là manager
                sta.StaffType != GlobalVariables.ManagerRole);
            if (staff is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Không tìm thấy staff với User Id {currentUserId}");
            }
            
            var date = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat,
                CultureInfo.InvariantCulture);
            var slots = await _repositoryWrapper.WorkSlot.FindByConditionAsync(ws =>
                ws.StaffId == staff.Id && ws.Date.DayOfYear == date.DayOfYear);
            if (slots is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "WorkSlots not found");
            }

            return new CustomHttpCodeResponse(200,"",slots.Select(ws => ws.ToGetWorkSlotResponseDTO()).ToList());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> FindWorkSlot(GetWorkSlotDTO getWorkSlotDTO)
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
            return new CustomHttpCodeResponse(200,"",slot.ToGetWorkSlotResponseDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AddAvailableWorkSlot(AddWorkSlotDTO addWorkSlotDTO)
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
            return new CustomHttpCodeResponse(200,"",result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AddAvailableWorkSlotBulk(ICollection<AddWorkSlotDTO> addWorkSlotsDTO)
        {
            //Check if dto is empty
            if (addWorkSlotsDTO.Count <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "List of WorkSlot is empty"); 
            }
            //Check if staff exists
            await CheckStaff(addWorkSlotsDTO.First().StaffId);

            //Get All SlotOfDay from Database
            var slotsOfDayIds = (await _repositoryWrapper.SlotOfDay.FindAllAsync()).Select(s => s.Id).ToList();
            //If any of the SlotOfDay Id is invalid, abort
            if (addWorkSlotsDTO.Any(slot => !slotsOfDayIds.Contains(slot.SlotOfDayId)))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Slot of day with id {slot.SlotOfDayId} doesn't exist");
            }

            foreach (var dto in addWorkSlotsDTO)
            {
                //Parse date
                var chosenDate = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
                //Check if There's Duplicate Work Slot
                var hasDuplicateWorkSlot = await _repositoryWrapper.WorkSlot.AnyAsync(ws =>
                    ws.StaffId == dto.StaffId && ws.Date == chosenDate && ws.SlotOfDayId == dto.SlotOfDayId);
                if (hasDuplicateWorkSlot)
                {
                    _repositoryWrapper.DeleteChanges();
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"There's already a duplicate slot at {dto.Date} and has SlotOfDay Id {dto.SlotOfDayId}");
                }

                await _repositoryWrapper.WorkSlot.CreateWithoutSaveAsync(dto.ToWorkSlot());
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
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went creating Work SLot in bulk: " + e.Message);
            }

            return new CustomHttpCodeResponse(200,"",true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateWorkSlot(UpdateWorkSlotDTO updateWorkSlotDTO)
        {
            //Check status is a valid status
            if (!GlobalVariables.WorkSlotStatuses.Contains(updateWorkSlotDTO.Status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Work SLot Status invalid, must be: available, not available");
            }
            
            //Get Work slot from Id
            var workSlot = await _repositoryWrapper.WorkSlot.FindSingleByConditionWithIncludeAsync(ws => ws.Id == updateWorkSlotDTO.Id, slot => slot.SlotOfDay);
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
            
            CheckDate(workSlot.Date);

            workSlot.Status = updateWorkSlotDTO.Status.ToLower();
            return new CustomHttpCodeResponse(200,"", (await _repositoryWrapper.WorkSlot.UpdateAsync(workSlot, workSlot.Id)).ToUpdateWorkSlotDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetWorkSlots(AdvancedGetWorkSlotsDTO advancedGetWorkSlotsDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetWorkSlotsDTO.SortBy) && !AdvancedGetWorkSlotsDTO.OrderingParams.Contains(advancedGetWorkSlotsDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetWorkSlotsDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.WorkSlot.AdvancedGetWorkSlots(advancedGetWorkSlotsDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }

        /// <summary>
        /// Fill work slot of a day of all staff for DEBUG
        /// </summary>
        public async Task<ActionResult<CustomHttpCodeResponse>> PopulateWorkSlot(string date)
        {
            var convertedDate = DateTime.ParseExact(date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var existedWorkslots =
                await _repositoryWrapper.WorkSlot.FindByConditionAsync(slot =>
                    slot.Date.DayOfYear == convertedDate.DayOfYear);
            if (existedWorkslots != null && existedWorkslots.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Day already has Work Slots, adding with this function will be dangerous");
            }

            //Get all active staff
            var staffs = await _repositoryWrapper.Staff.FindByConditionAsync(staff =>
                staff.User.Status == GlobalVariables.ActiveUserStatus &&
                (staff.StaffType == GlobalVariables.StylistRole || staff.StaffType == GlobalVariables.BeauticianRole));

            var slots = await _repositoryWrapper.SlotOfDay.FindAllAsync();

            foreach (var staff in staffs)
            {
                foreach (var slot in slots)
                {
                    await _repositoryWrapper.WorkSlot.CreateWithoutSaveAsync(new WorkSlot()
                    {
                        StaffId = staff.Id,
                        Date = convertedDate,
                        SlotOfDayId = slot.Id,
                        Status = GlobalVariables.AvailableWorkSlotStatus
                    });
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
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went Populating Work Slots: " + e.Message);
            }
            
            return new CustomHttpCodeResponse(200,"Work Slots created", true);
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
        
        /// <summary>
        /// Check if inputted date is valid, can be a day before and can be more than 2 weeks in the future
        /// </summary>
        private void CheckDate(DateTime date)
        {
            //Get Now time
            var now = DateTime.Now;
            
            //If Date is before or is current date
            if (now.AddMinutes(GlobalVariables.TimeToCreateAppointmentInAdvanced) >= date)
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Chỉ có thể update Work Slot đang cách hiện tại hơn {GlobalVariables.TimeToCreateAppointmentInAdvanced} phút");
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