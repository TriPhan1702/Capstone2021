using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class AdvancedGetWorkSlotsDTO : PaginationParams
    {
        public static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "id_asc", "id_desc", 
                "staffid_asc","staffid_desc", 
                "staffname_asc", "staffname_desc", 
                "slotofdayid_asc", "slotofdayid_desc", 
                "starttime_asc", "starttime_desc",
                "date_asc", "date_desc",
                "endtime_asc", "endtime_desc", 
                "status_asc", "status_desc",}
        );
        
        public ICollection<string> Statuses { get; set; }
        public ICollection<int> StaffIds { get; set; } 
        public ICollection<int> SlotOfDayIds { get; set; } 
        public ICollection<string> ExactStaffNames { get; set; }
        public string StaffName { get; set; }
        
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        public string MinTime { get; set; }
        public string MaxTime { get; set; }
        
        public string SortBy { get; set; }
    }
}