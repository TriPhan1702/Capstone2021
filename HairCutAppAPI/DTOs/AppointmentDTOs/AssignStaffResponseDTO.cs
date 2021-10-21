using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class AssignStaffResponseDTO
    {
        public int AppointmentId { get; set; }
        public IEnumerable<AssignStaffDetailResponseDTO> StaffDetailResponseDTOs { get; set; }
    }
    
    public class AssignStaffDetailResponseDTO
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}