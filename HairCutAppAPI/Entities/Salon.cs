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
        
        public string Address { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        
        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        
        //Many-Many
        public virtual ICollection<SalonsCodes> SalonsCodes { get; set; }
        
        public CustomerGetSalonListResponseDTO ToCustomerGetSalonListDTO()
        {
            var result = new CustomerGetSalonListResponseDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Latitude = Latitude?.ToString(),
                Longitude = Longitude?.ToString(),
                AvatarUrl = AvatarUrl,
                Address = Address,
                Status = Status
            };

            return result;
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
                Address = Address
            };
            if (Longitude != null)
            {
                result.Longitude = Longitude.ToString();
            }
            if (Latitude != null)
            {
                result.Longitude = Latitude.ToString();
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
                Address = Address,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdate = LastUpdate.ToString(GlobalVariables.DateTimeFormat),
            };
        }

        public GetSalonDetailDTO ToGetSalonDetailDTO()
        {
            return new GetSalonDetailDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Latitude = Latitude,
                Longitude = Longitude,
                AvatarUrl = AvatarUrl,
                Address = Address,
                Status = Status
            };
        }

        public UpdateSalonResponseDTO ToUpdateSalonResponseDTO()
        {
            return new UpdateSalonResponseDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Status = Status,
                Latitude = Latitude,
                Longitude = Longitude,
                AvatarUrl = AvatarUrl
            };
        }
    }
}