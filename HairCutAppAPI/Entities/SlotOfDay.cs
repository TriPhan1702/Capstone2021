using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.Entities
{
    public class SlotOfDay
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int StartTime { get; set; }
        
        [Required]
        public int EndTime { get; set; }
        
        public ICollection<WorkSlot> WorkSlots { get; set; }
    }
}