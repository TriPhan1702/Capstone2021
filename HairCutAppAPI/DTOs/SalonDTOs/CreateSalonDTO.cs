using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CreateSalonDTO
    {
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        
        public string Address { get; set; }
        
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public Salon ToNewSalon()
        {
            var now = DateTime.Now;
            
            var result = new Salon()
            {
                Name = Name,
                Description = Description,
                CreatedDate = now,
                LastUpdate = now,
                Status = GlobalVariables.NewSalonStatus,
                Address = Address,
            };

            if (!string.IsNullOrWhiteSpace(Longitude) && !string.IsNullOrWhiteSpace(Latitude))
            {
                try
                {
                    result.Longitude = double.Parse(Longitude);
                    result.Latitude = double.Parse(Latitude);
                }
                catch (FormatException)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Format của tọa độ là không đúng");
                }
            }

            return result;
        }
    }
}