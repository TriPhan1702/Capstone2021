using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IWorkSlotRepository : IRepositoryBase<WorkSlot>
    {
        Task<PagedList<AdvancedGetWorkSlotsResponseDTO>> AdvancedGetWorkSlots(AdvancedGetWorkSlotsDTO advancedGetWorkSlotsDTO);

        Task<ICollection<WorkSlot>> GetAvailableWorkSlotsDetailFromStaffListAndSlotOfDayListAndDate(DateTime date,
            IEnumerable<int> staffIds,
            IEnumerable<int> slotsOfDayIds);
    }
}