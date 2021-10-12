using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class ChangeAppointmentStatusDTO
    {
        public int AppointmentId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
    }
}