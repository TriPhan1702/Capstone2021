using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.DTOs.ComboDTOs;
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
        public int Duration { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        
        [Required]
        public long Price { get; set; }
        
        //Many-Many
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }

        public ServiceDTO ToServiceDTO()
        {
            return new ServiceDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Price = Price,
                Duration = Duration,
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
                Name = Description,
                Price = Price,
                Duration = Duration,
            };
        }

        public UpdateComboResponseServiceDTO ToUpdateComboResponseServiceDTO()
        {
            return new UpdateComboResponseServiceDTO()
            {
                Id = Id,
                Name = Name
            };
        }
    }
}