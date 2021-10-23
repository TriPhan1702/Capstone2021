using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class Salon
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        
        [Required]
        public DateTime LastUpdate { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        
        //Many-Many
        public ICollection<SalonsCodes> SalonsCodes { get; set; }
        
        public CustomerGetSalonListDTO ToCustomerGetSalonListDTO()
        {
            return new CustomerGetSalonListDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Latitude = Latitude?.ToString(),
                Longitude = Longitude?.ToString(),
                AvatarUrl = AvatarUrl,
            };
        } 
        
        public CreateSalonResponseDTO ToCreateSalonResponseDTO()
        {
            
            var now = DateTime.Now;
            var result = new CreateSalonResponseDTO()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                AvatarUrl = AvatarUrl,
            };
            if (Longitude != null)
            {
                result.Longitude = Longitude.ToString();
            }
            if (Latitude != null)
            {
                result.Longitude = Longitude.ToString();
            }

            return result;
        }

        public AdvancedGetSalonResponseDTO ToAdvancedGetSalonResponseDTO()
        {
            return new AdvancedGetSalonResponseDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Status = Status,
                AvatarUrl = AvatarUrl,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdate = LastUpdate.ToString(GlobalVariables.DateTimeFormat),
            };
        }

        // public CustomerGetSalonDetailDTO ToCustomerGetSalonDetailDTO(ICollection<Combo> combos)
        // {
        //     var result = new CustomerGetSalonDetailDTO()
        //     {
        //         Id = Id,
        //         Description = Description,
        //         Name = Name,
        //         Latitude = Latitude,
        //         Longitude = Longitude,
        //         AvatarUrl = AvatarUrl,
        //         ComboDetailDTOs = new List<ComboDetailDTO>()
        //     };
        //
        //     foreach (var combo in combos)
        //     {
        //         
        //     }
        // }
    }
}