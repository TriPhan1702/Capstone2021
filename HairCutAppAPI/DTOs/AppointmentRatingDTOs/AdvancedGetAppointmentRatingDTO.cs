using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.AppointmentRatingDTOs
{
    public class AdvancedGetAppointmentRatingDTO : PaginationParams
    {
        public static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { 
                "id_asc", "id_desc", 
                "appointmentid_asc", "appointmentid_desc", 
                "rating_asc", "rating_desc",
            }
        );
        
        public IEnumerable<int> FilterIds { get; set; }
        public IEnumerable<int> FilterAppointmentIds { get; set; }
        public string SortBy { get; set; }
    }
}