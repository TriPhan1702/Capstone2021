using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetAppointmentStatusStatInMonthByStaffDTO
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int StaffUserId { get; set; }
    }
}