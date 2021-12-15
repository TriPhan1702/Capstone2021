namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class TopCustomerResponseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int TotalAppointment { get; set; }
        public long TotalPayment { get; set; }
    }
}