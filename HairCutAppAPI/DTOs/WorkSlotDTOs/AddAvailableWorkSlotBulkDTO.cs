using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class AddAvailableWorkSlotBulkDTO
    {
        [Required]
        public int StaffId { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
    }
}