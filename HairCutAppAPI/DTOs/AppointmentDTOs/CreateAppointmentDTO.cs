using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class CreateAppointmentDTO
    {
        public int SalonId { get; set; }
        
        [MinLength(3), MaxLength(255)]
        public string PromotionalCode { get; set; }
        
        public int StartSlotOfDayId { get; set; }
        
        [Required]
        [RegularExpression(GlobalVariables.DateRegex, ErrorMessage = GlobalVariables.DateRegexMessage)]
        public string Date { get; set; }
        
        public int ComboId { get; set; }
        
        public int StylistStaffId { get; set; } 
    }
}