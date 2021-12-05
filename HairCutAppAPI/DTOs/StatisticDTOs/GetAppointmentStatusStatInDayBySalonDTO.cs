using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetAppointmentStatusStatInDayBySalonDTO
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int SalonId { get; set; }
    }
}