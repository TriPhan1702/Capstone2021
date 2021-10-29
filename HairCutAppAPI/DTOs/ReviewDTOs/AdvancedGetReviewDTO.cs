using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.ReviewDTOs
{
    public class AdvancedGetReviewDTO : PaginationParams
    {
        public new static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "id_asc", "id_desc",
                "salonid_asc","salonid_desc", 
                "customerid_asc", "customerid_desc", 
                "customeruserid_asc", "customeruserid_desc", 
                "salonname_asc", "salonname_desc", 
                "customername_asc", "customername_desc",
                "rating_asc", "rating_desc",
                "createddate_asc", "createddate_desc",
            }
        );
        
        public IEnumerable<int> Ids { get; set; }
        public IEnumerable<int> SalonIds { get; set; }
        public IEnumerable<int> CustomerIds { get; set; }
        public IEnumerable<int> CustomerUserIds { get; set; }
        public string ContainSalonName { get; set; }
        public string ContainCustomerName { get; set; }
        public string MinCreatedDate { get; set; }
        public string MaxCreatedDate { get; set; }
        
        // public string MinLastUpdate { get; set; }
        // public string MaxLastUpdate { get; set; }
        public int Rating { get; set; }
        public string SortBy { get; set; }
    }
}