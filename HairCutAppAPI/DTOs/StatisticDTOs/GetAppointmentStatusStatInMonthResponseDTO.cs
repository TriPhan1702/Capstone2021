namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetAppointmentStatusStatInMonthResponseDTO
    {
        public int PendingAppointments { get; set; }
        public int ApprovedAppointments { get; set; }
        public int OnGoingAppointments { get; set; }
        public int CancelAppointments { get; set; }
        public int TotalAppointments { get; set; }
    }
}