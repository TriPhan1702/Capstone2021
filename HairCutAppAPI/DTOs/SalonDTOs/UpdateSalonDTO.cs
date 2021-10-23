using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class UpdateSalonDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Salon CompareAndMapToSalon(Salon salon)
        {
            //If name is not null, mapp
            if (!string.IsNullOrWhiteSpace(Name))
            {
                salon.Name = Name;
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                salon.Description = Description;
            }
            
            //TODO:MAP Image

            if (!string.IsNullOrWhiteSpace(Status))
            {
                salon.Status = Status;
            }

            if (Longitude >= 0)
            {
                salon.Longitude = Longitude;
            }

            if (Latitude >= 0)
            {
                salon.Latitude = Latitude;
            }

            return salon;
        }
    }
}