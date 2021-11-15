using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.ComboDTOs
{
    public class CreateUpdateComboDetailDTO
    {
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public bool IsDoneByStylist { get; set; }
        
        public int ServiceOrder { get; set; }
    }
}