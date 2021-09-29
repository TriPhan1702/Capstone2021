using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        
        //Many-Many
        public ICollection<ServicesStaffs> ServicesStaffs { get; set; }
        
        //Many-Many
        public ICollection<CombosServices> CombosServices { get; set; }
        
        //Many-Many
        public ICollection<AppointmentsServices> AppointmentsServices { get; set; }
    }
}