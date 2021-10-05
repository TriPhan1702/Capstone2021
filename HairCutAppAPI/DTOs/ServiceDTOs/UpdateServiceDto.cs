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
        
        public int? Duration { get; set; }
        
        public decimal? Price { get; set; }

        public Service CompareUpdateService(Service service)
        {
            if (!string.IsNullOrWhiteSpace(Name) && Name != service.Name)
            {
                service.Name = Name;
            }

            if (!string.IsNullOrWhiteSpace(Description) && Description != service.Description)
            {
                service.Description = Description;
            }

            if (!string.IsNullOrWhiteSpace(Status) && Status != service.Status)
            {
                service.Status = Status;
            }
            
            if ( Duration != null && Duration != service.Duration)
            {
                service.Duration = Duration.Value;
            }
            
            if ( Price != null && Price != service.Price)
            {
                service.Price = Price.Value;
            }

            return service;
        }
    }
}