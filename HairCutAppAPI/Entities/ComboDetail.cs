﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class ComboDetail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo Combo { get; set; }
        
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        
        [Required]
        public bool IsDoneByStylist { get; set; }
        
        [Required]
        public int ServiceOrder { get; set; }
        
        public virtual Service Service { get; set; }
    }
}