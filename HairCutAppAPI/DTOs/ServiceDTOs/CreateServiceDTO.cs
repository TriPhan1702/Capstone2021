using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.ServiceDTOs
{
    public class CreateServiceDTO
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int Duration { get; set; }

        public Service ToNewService()
        {
            return new Service()
            {
                Name = Name,
                Description = Description,
                Price = Price,
                CreatedDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                Duration = Duration
            };
        }
    }
}