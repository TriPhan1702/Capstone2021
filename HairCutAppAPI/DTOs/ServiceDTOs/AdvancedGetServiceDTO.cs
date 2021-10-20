using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.ServiceDTOs
{
    public class AdvancedGetServiceDTO : PaginationParams
    {
        public static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { 
                "id_asc", "id_desc", 
                "name_asc", "name_desc", 
                "status_asc", "status_desc",
                "createddate_asc","createddate_desc",
                "lastupdate_asc","lastupdate_desc",
                "price_asc","price_desc"}
        );
        
        public ICollection<string> Statuses { get; set; }
        public string Name { get; set; }
        
        public string MinCreatedDate { get; set; }
        public string MaxCreatedDate { get; set; }
        public string MinLastUpdate { get; set; }
        public string MaxLastUpdate { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        
        public string SortBy { get; set; }
    }
}