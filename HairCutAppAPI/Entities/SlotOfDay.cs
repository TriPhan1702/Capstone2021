using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.DTOs.SlotOfDayDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class SlotOfDay
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan EndTime { get; set; }
        
        public virtual ICollection<WorkSlot> WorkSlots { get; set; }

        public SlotOfDayDTO ToSlotOfDayDTO()
        {
            return new SlotOfDayDTO()
            {
                Id = Id,
                EndTime = EndTime.ToString(GlobalVariables.TimeFormat),
                StartTime = StartTime.ToString(GlobalVariables.TimeFormat),
            };
        }
    }
}