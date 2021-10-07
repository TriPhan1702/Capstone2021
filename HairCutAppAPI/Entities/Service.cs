using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        //Many-Many
        public ICollection<ComboDetail> ComboDetails { get; set; }

        public ServiceDTO ToServiceDTO()
        {
            return new ServiceDTO()
            {
                Id = Id,
                Description = Description,
                Duration = Duration,
                Name = Name,
                Price = Price,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdated = LastUpdated.ToString(GlobalVariables.DateTimeFormat)
            };
        }

        public UpdateServiceResponseDto ToUpdateServiceResponseDto()
        {
            return new UpdateServiceResponseDto()
            {
                Id = Id,
                Description = Description,
                Duration = Duration,
                Name = Description,
                Price = Duration,
                Status = Status
            };
        }
    }
}