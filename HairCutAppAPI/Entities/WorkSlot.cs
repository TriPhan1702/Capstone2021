using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class WorkSlot
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        
        [ForeignKey("SlotOfDay")]
        public int SlotOfDayId { get; set; }
        public SlotOfDay SlotOfDay { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
    }
}