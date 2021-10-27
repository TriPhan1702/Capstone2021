using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class AdvancedGetPromotionalCodesResponseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdate { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsUniversal { get; set; }
    }
}