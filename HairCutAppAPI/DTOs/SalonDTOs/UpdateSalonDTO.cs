using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;

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
        public string Address { get; set; }
        
        public IFormFile AvatarFile { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Salon CompareAndMapToSalon(Salon salon)
        {
            var hasChanged = false;
            //If name is not null, map
            if (!string.IsNullOrWhiteSpace(Name) && Name != salon.Name)
            {
                salon.Name = Name;
                hasChanged = true;
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                salon.Description = Description;
                hasChanged = true;
            }

            if (!string.IsNullOrWhiteSpace(Status) && Status.ToLower() != salon.Status.ToLower())
            {
                salon.Status = Status;
                hasChanged = true;
            }
            
            if (!string.IsNullOrWhiteSpace(Address) && Address.ToLower() != salon.Address.ToLower())
            {
                salon.Address = Address;
                hasChanged = true;
            }

            if (Longitude >= 0)
            {
                salon.Longitude = Longitude;
                hasChanged = true;
            }

            if (Latitude >= 0)
            {
                salon.Latitude = Latitude;
                hasChanged = true;
            }

            if (hasChanged)
            {
                salon.LastUpdate = DateTime.Now;
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Nothing can be changed with the provided information");
            }

            return salon;
        }
    }
}