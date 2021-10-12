using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CreateSalonDTO
    {
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }
        
        //TODO: Validate coordinate
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public Salon ToNewSalon()
        {
            var now = DateTime.Now;
            
            var result = new Salon()
            {
                Name = Name,
                Description = Description,
                AvatarUrl = AvatarUrl,
                CreatedDate = now,
                LastUpdate = now,
                Status = GlobalVariables.NewSalonStatus
            };

            if (!string.IsNullOrWhiteSpace(Longitude) && !string.IsNullOrWhiteSpace(Latitude))
            {
                result.Longitude = double.Parse(Longitude);
                result.Latitude = double.Parse(Latitude);
            }

            return result;
        }
    }
}