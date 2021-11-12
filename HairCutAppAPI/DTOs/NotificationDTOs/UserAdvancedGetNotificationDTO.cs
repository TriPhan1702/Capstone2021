using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.NotificationDTOs
{
    public class UserAdvancedGetNotificationDTO : PaginationParams
    {
        public new static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "id_asc", "id_desc",
                "userid_asc","userid_desc", 
                "appointmentid_asc", "appointmentid_desc", 
                "createddate_asc", "createddate_desc", 
                "lastupdate_asc", "lastupdate_desc", 
                "status_asc", "status_desc",
            }
        );

        public List<int> FilterByIds { get; set; }
        public List<int> FilterByAppointmentId { get; set; }
        public List<string> Statuses { get; set; }
        public string MinLastUpdate { get; set; }
        public string MaxLastUpdate { get; set; }
        public string MinCreatedDate { get; set; }
        public string MaxCreatedDate { get; set; }
        public string SortBy { get; set; }
    }
}