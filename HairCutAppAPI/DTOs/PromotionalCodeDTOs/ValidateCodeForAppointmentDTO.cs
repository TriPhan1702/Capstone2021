using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class ValidateCodeForAppointmentDTO
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public int SalonId { get; set; }
        
        [Required]
        public int ComboId { get; set; }
    }
}