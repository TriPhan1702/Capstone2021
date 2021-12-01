using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class UpdatePromotionalCodeResponseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Percentage { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsUniversal { get; set; }
        public int UsesPerCustomer { get; set; }
        public string Status { get; set; }
        public List<UpdatePromotionalCodeResponseSalonDTO> Salons { get; set; }
    }

    public class UpdatePromotionalCodeResponseSalonDTO
    {
        public int SalonId { get; set; }
        public string SalonName { get; set; }
    }
}