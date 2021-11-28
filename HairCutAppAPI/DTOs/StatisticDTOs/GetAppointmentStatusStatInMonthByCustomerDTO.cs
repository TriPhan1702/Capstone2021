using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetAppointmentStatusStatInMonthByCustomerDTO
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int CustomerUserId { get; set; }
    }
}