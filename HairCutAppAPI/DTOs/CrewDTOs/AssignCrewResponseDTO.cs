using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.CrewDTOs
{
    public class AssignCrewResponseDTO
    {
        public int AppointmentId { get; set; }
        public ICollection<int> StaffIds { get; set; }
    }
}