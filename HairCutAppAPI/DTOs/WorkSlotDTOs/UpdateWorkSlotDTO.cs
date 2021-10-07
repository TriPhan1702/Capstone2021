using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class UpdateWorkSlotDTO
    {
        public int Id { get; set; }

        [Required] 
        [MaxLength(20)] 
        public string Status { get; set; }
    }
}