using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class AssignStaffDTO
    {
        public int AppointmentId { get; set; }
        [Required]
        public ICollection<AssignStaffDetailDTO> StaffDetailDTOs { get; set; }
    }

    public class AssignStaffDetailDTO
    {
        public int StaffId { get; set; }
        public int ServiceId { get; set; }
    }
}