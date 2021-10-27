using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class AdvancedGetPromotionalCodesDTO : PaginationParams
    {
        public new static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "id_asc", "id_desc",
                "code_asc","code_desc", 
                "percentage_asc", "percentage_desc", 
                "createddate_asc", "createddate_desc", 
                "lastupdate_asc", "lastupdate_desc", 
                "startdate_asc", "startdate_desc",
                "expirationdate_asc", "expirationdate_desc",
                "isuniversal_asc", "isuniversal_desc",
                "usespercustomer_asc", "usespercustomer_desc",
                "status_asc", "status_desc",
            }
        );

        public string Code { get; set; }
        public int IsUniversal { get; set; }
        public List<string> Statuses { get; set; }
        public decimal MinPercentage { get; set; }
        public decimal MaxPercentage { get; set; }
        public string MinCreatedDate { get; set; }
        public string MaxCreatedDate { get; set; }
        public string MinLastUpdate { get; set; }
        public string MaxLastUpdate { get; set; }
        public string MinStartDate { get; set; }
        public string MaxStartDate { get; set; }
        public string MinExpirationDate { get; set; }
        public string MaxExpirationDate { get; set; }
        public int MinUsesPerCustomer { get; set; }
        public int MaxUsesPerCustomer { get; set; }
        public string SortBy { get; set; }
    }
}