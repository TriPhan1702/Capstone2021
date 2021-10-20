using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.StaffDTOs
{
    public class AdvancedGetStaffDTO : PaginationParams
    {
        public static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "userid_asc", "userid_desc",
                "staffid_asc", "staffid_desc", 
                "salonid_asc", "salonid_desc",
                "salonname_asc", "salonname_desc",
                "email_asc", "email_desc",
                "fullname_asc", "fullname_desc", 
                "status_asc", "status_desc",
                "stafftypes_asc", "stafftype_desc"
            }
        );
        
        public ICollection<int> UserIds { get; set; }
        public ICollection<int> StaffIds { get; set; }
        public ICollection<int> SalonIds { get; set; }
        public ICollection<string> StaffTypes { get; set; }
        public ICollection<string> Statuses { get; set; }
        public string SortBy { get; set; }
        public string FullName { get; set; }
        public string SalonName { get; set; }
        public string Email { get; set; }
    }
}