using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.Entities
{
    public class Crew
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        
        public ICollection<CrewDetail> CrewDetails { get; set; }
    }
}