using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.StaffDTOs
{
    public class GetAvailableStylistsOfASalonInSpanOfDayDTO
    {
        [Required]
        public int SalonId { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
    }
}