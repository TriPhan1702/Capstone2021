namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetTopStaffResponseDTO
    {
        public int StaffId { get; set; }
        public int StaffUserId { get; set; }
        public string FullName { get; set; }
        public int TotalAppointment { get; set; }
        public string StaffType { get; set; }
    }
}