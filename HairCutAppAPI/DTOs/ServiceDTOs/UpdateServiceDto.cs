using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.ServiceDTOs
{
    public class UpdateServiceDto
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [MaxLength(20)]
        public string Status { get; set; }
        
        public decimal Price { get; set; }

        public Service CompareUpdateService(Service service)
        {
            var changes = 0;
            if (!string.IsNullOrWhiteSpace(Name) && Name != service.Name)
            {
                service.Name = Name;
                changes++;
            }

            if (!string.IsNullOrWhiteSpace(Description) && Description != service.Description)
            {
                service.Description = Description;
                changes++;
            }

            if (!string.IsNullOrWhiteSpace(Status) && Status != service.Status)
            {
                service.Status = Status.ToLower();
                changes++;
            }
            
            if ( Price >= 0 && Price != service.Price)
            {
                service.Price = Price;
                changes++;
            }

            if (changes>0)
            {
                service.LastUpdated = DateTime.Now;
            }

            return service;
        }
    }
}