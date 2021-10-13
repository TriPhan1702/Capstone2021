using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.CrewDTOs
{
    public class AssignCrewDTO
    {
        public int AppointmentId { get; set; }
        public ICollection<int> StaffIds { get; set; }
    }
}