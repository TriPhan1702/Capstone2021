using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.Entities
{
    public class Salon
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        
        [Required]
        public DateTime LastUpdate { get; set; }
        
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Review> Reviews { get; set; }
        
        //Many-Many
        public ICollection<SalonsCodes> SalonsCodes { get; set; }
    }
}