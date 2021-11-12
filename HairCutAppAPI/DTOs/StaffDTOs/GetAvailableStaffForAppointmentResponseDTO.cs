namespace HairCutAppAPI.DTOs.StaffDTOs
{
    public class GetAvailableStaffForAppointmentResponseDTO
    {
        public int StaffId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string StaffType { get; set; }
        public string AvatarUrl { get; set; }
        public int NumberOfAppointmentsOnDate { get; set; }
    }
}