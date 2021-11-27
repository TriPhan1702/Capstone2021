using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class FindWorkSlotOfDayBySalonDTO
    {
        public int SalonId { get; set; }
        public string Date { get; set; }
        public List<FindWorkSlotOfDayBySalonStaffDTO> Staffs { get; set; }
    }

    public class FindWorkSlotOfDayBySalonStaffDTO
    {
        public int StaffId { get; set; }
        public int StaffUserId { get; set; }
        public string Name { get; set; }
        public List<FindWorkSlotOfDayBySalonWorkSlotDTO> WorkSlots { get; set; }
    }
    public class FindWorkSlotOfDayBySalonWorkSlotDTO
    {
        public int WorkSlotId { get; set; }
        public int SlotOfDayId { get; set; }
        
        public string Status { get; set; }
        public int? AppointmentId { get; set; }
        public int? AppointmentDetailId { get; set; }
    }
}