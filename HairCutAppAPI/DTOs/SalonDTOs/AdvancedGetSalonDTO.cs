using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class AdvancedGetSalonDTO : PaginationParams
    {
        public new static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "id_asc", "id_desc", "name_asc", "name_desc", "status_asc", "status_desc","createddate_asc","createddate_desc","lastupdate_asc","lastupdate_desc"}
        );
        
        public ICollection<string> Statuses { get; set; }
        
        public string MinCreatedDate { get; set; }
        public string MaxCreatedDate { get; set; }
        public string MinLastUpdate { get; set; }
        public string MaxLastUpdate { get; set; }
        
        public string SortBy { get; set; }
    }
}