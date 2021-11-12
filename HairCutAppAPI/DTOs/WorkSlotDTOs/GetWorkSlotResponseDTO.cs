namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class GetWorkSlotResponseDTO
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int SlotOfDayId { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        
        public int? AppointmentId { get; set; }
    }
}