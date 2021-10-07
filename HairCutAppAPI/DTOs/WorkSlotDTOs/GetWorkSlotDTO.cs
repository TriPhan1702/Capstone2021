using System;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class GetWorkSlotDTO
    {
        public int StaffId { get; set; }
        
        public int SlotOfDayId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
    }
}