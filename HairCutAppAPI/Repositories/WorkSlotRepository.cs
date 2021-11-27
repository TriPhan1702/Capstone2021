using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class WorkSlotRepository : RepositoryBase<WorkSlot>, IWorkSlotRepository
    {
        private readonly HDBContext _hdbContext;

        public WorkSlotRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<PagedList<AdvancedGetWorkSlotsResponseDTO>> AdvancedGetWorkSlots(AdvancedGetWorkSlotsDTO advancedGetWorkSlotsDTO)
        {
            var query = _hdbContext.WorkSlots.Include(slot => slot.Staff).Include(slot => slot.SlotOfDay).AsQueryable();
            //If there's status filtering
            if (advancedGetWorkSlotsDTO.Statuses != null && advancedGetWorkSlotsDTO.Statuses.Any())
            {
                query = query.Where(slot =>
                    advancedGetWorkSlotsDTO.Statuses.Select(status => status.ToLower()).Contains(slot.Status.ToLower()));
            }
            
            //If there's staffId filtering
            if (advancedGetWorkSlotsDTO.StaffIds != null && advancedGetWorkSlotsDTO.StaffIds.Any())
            {
                query = query.Where(slot =>
                    advancedGetWorkSlotsDTO.StaffIds.Contains(slot.StaffId));
            }
            
            //If there's staffId filtering
            if (advancedGetWorkSlotsDTO.FilterSalonIds != null && advancedGetWorkSlotsDTO.FilterSalonIds.Any())
            {
                query = query.Where(slot =>
                    advancedGetWorkSlotsDTO.FilterSalonIds.Contains(slot.Staff.SalonId.Value));
            }
            
            //If there's slot of day id filtering
            if (advancedGetWorkSlotsDTO.SlotOfDayIds != null && advancedGetWorkSlotsDTO.SlotOfDayIds.Any())
            {
                query = query.Where(slot =>
                    advancedGetWorkSlotsDTO.SlotOfDayIds.Contains(slot.SlotOfDayId));
            }
            
            //If there's exact staff name filtering
            if (advancedGetWorkSlotsDTO.ExactStaffNames != null && advancedGetWorkSlotsDTO.ExactStaffNames.Any())
            {
                query = query.Where(slot =>
                    advancedGetWorkSlotsDTO.ExactStaffNames.Select(name => name.ToLower()).Contains(slot.Staff.FullName.ToLower()));
            }

            //If There's Name Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetWorkSlotsDTO.StaffName))
            {
                query = query.Where(slot => slot.Staff.FullName.ToLower().Contains(advancedGetWorkSlotsDTO.StaffName.ToLower()));
            }

            try
            {
                //If there's Date Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetWorkSlotsDTO.MinDate))
                {
                    var date = DateTime.ParseExact(advancedGetWorkSlotsDTO.MinDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(slot => slot.Date >= date);
                }

                //If there's Date Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetWorkSlotsDTO.MaxDate))
                {
                    var date = DateTime.ParseExact(advancedGetWorkSlotsDTO.MaxDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(slot => slot.Date <= date);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.DateTimeFormat);
            }
            
            try
            {
                //If there's time Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetWorkSlotsDTO.MinTime))
                {
                    var time = TimeSpan.Parse(advancedGetWorkSlotsDTO.MinTime);
                    query = query.Where(slot => slot.SlotOfDay.StartTime >= time);
                }

                //If there's time Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetWorkSlotsDTO.MaxTime))
                {
                    var time = TimeSpan.Parse(advancedGetWorkSlotsDTO.MaxTime);
                    query = query.Where(slot => slot.SlotOfDay.EndTime <= time);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.TimeFormat);
            }

            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetWorkSlotsDTO.SortBy))
            {
                query = advancedGetWorkSlotsDTO.SortBy switch
                {
                    "id_asc" => query.OrderBy(slot => slot.Id),
                    "id_desc" => query.OrderByDescending(slot => slot.Id),
                    "slotofdayid_asc" => query.OrderBy(slot => slot.SlotOfDayId),
                    "slotofdayid_desc" => query.OrderByDescending(slot => slot.SlotOfDayId),
                    "staffid_asc" => query.OrderBy(slot => slot.Staff.Id),
                    "staffid_desc" => query.OrderByDescending(slot => slot.Staff.Id),
                    "staffname_asc" => query.OrderBy(slot => slot.Staff.FullName),
                    "staffname_desc" => query.OrderByDescending(slot => slot.Staff.FullName),
                    "status_asc" => query.OrderBy(slot => slot.Status),
                    "status_desc" => query.OrderByDescending(slot => slot.Status),
                    "starttime_asc" => query.OrderBy(slot => slot.SlotOfDay.StartTime),
                    "starttime_desc" => query.OrderByDescending(slot => slot.SlotOfDay.StartTime),
                    "endtime_asc" => query.OrderBy(slot => slot.SlotOfDay.EndTime),
                    "endtime_desc" => query.OrderByDescending(slot => slot.SlotOfDay.EndTime),
                    "date_asc" => query.OrderBy(slot => slot.Date),
                    "date_desc" => query.OrderByDescending(slot => slot.Date),
                    _ => query
                };
            }

            return await PagedList<AdvancedGetWorkSlotsResponseDTO>.CreateAsync(
                query.Select(slot => slot.ToAdvancedGetWorkSlotResponseDTO()), advancedGetWorkSlotsDTO.PageNumber,
                advancedGetWorkSlotsDTO.PageSize);
        }

        public async Task<ICollection<WorkSlot>> GetAvailableWorkSlotsDetailFromStaffListAndSlotOfDayListAndDate(DateTime date, IEnumerable<int> staffIds,
            IEnumerable<int> slotsOfDayIds)
        {
            return await _hdbContext.WorkSlots.Include(slot => slot.SlotOfDay).Where(ws => slotsOfDayIds.Contains(ws.SlotOfDayId) &&
                                                                             staffIds.Contains(ws.StaffId) &&
                                                                             ws.Status == GlobalVariables.AvailableWorkSlotStatus &&
                                                                             ws.Date.DayOfYear == date.DayOfYear).ToListAsync();
        }

        public async Task<IEnumerable<WorkSlot>> GetAvailableWorkSlotsWithSlotOfDay()
        {
            return await _hdbContext.WorkSlots.Include(slot => slot.SlotOfDay)
                .Where(slot => slot.Status == GlobalVariables.AvailableWorkSlotStatus).ToListAsync();
        }
    }
}