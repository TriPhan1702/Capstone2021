using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities.Errors;

namespace HairCutAppAPI.DTOs.ServiceDTOs
{
    public class UpdateServiceDto
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public long Price { get; set; }

        public Service CompareUpdateService(Service service)
        {
            var hasChanged = false;
            if (!string.IsNullOrWhiteSpace(Name) && Name != service.Name)
            {
                service.Name = Name;
                hasChanged = true;
            }

            if (!string.IsNullOrWhiteSpace(Description) && Description != service.Description)
            {
                service.Description = Description;
                hasChanged = true;
            }
            
            if ( Price >= 0 && Price != service.Price)
            {
                service.Price = Price;
                hasChanged = true;
            }
            
            if ( Duration >= 0 && Duration != service.Duration)
            {
                service.Duration = Duration;
                hasChanged = true;
            }

            if (hasChanged)
            {
                service.LastUpdated = DateTime.Now;
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Không có thông tin nào thay đổi được dựa trên thông tin từ dto");
            }

            return service;
        }
    }
}