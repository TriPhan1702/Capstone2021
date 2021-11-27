namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class AdvancedGetWorkSlotsResponseDTO
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int SlotOfDayId { get; set; }
        public int SalonId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        
        public int? AppointmentId { get; set; }
        public int? AppointmentDetailId { get; set; }
    }
}