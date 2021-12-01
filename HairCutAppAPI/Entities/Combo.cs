using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class Combo
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
        public long Price { get; set; }
        
        public string AvatarUrl { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        
        //Many-Many
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
        
        public virtual ICollection<Appointment> Appointments { get; set;}

        public ComboDTO ToComboDTO()
        {
            return new ComboDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Status = Status,
                Price = Price,
                AvatarUrl = AvatarUrl
            };
        }

        public UpdateComboResponseDTO ToUpdateComboResponseDTO()
        {
            return new UpdateComboResponseDTO()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Status = Status,
                Price = Price
            };
        }

        public AdvancedGetCombosResponseDTO ToAdvancedGetCombosResponseDTO()
        {
            return new AdvancedGetCombosResponseDTO()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdated = LastUpdated.ToString(GlobalVariables.DateTimeFormat),
                Price = Price,
                AvatarUrl = AvatarUrl
            };
        }

        public ComboDetailDTO ToComboDetailDTO()
        {
            return new ComboDetailDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Price = Price,
                AvatarUrl = AvatarUrl,
                Status = Status,
                Services = ComboDetails.Select(detail => new ComboDetailServiceDTO()
                {
                    Id = detail.ServiceId,
                    Name = detail.Service.Name,
                    Description = detail.Service.Description,
                    Price = detail.Service.Price,
                }).ToList(),
            };
        }
    }
}