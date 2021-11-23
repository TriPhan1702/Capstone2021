using System;
using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class GetPromotionalCodeDetailResponseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdate { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsUniversal { get; set; }
        public int UsesPerCustomer { get; set; }
        public string Status { get; set; }
        public IEnumerable<GetPromotionalCodeDetailResponseSalonDTO> Salons { get; set; }
    }

    public class GetPromotionalCodeDetailResponseSalonDTO
    {
        public int SalonId { get; set; }
        public string SalonName { get; set; }
    }
}