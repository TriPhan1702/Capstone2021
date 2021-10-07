using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class AddWorkSlotDTO
    {
        public int StaffId { get; set; }
        
        public int SlotOfDayId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        public WorkSlot ToWorkSlot()
        {
            return new WorkSlot()
            {
                StaffId = StaffId,
                SlotOfDayId = SlotOfDayId,
                //Available
                Status = GlobalVariables.WorkSlotStatuses[0],
                Date = Date
            };
        }
    }
}