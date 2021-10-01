using System;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CreateSalonDTO
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }
        
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}