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
        
        public CustomerGetSalonListResponseDTO ToCustomerGetSalonListDTO(double? longitude = null, double? latitude = null)
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
                Distance = null
            };

            if (longitude != null && latitude != null && Latitude != null && Longitude != null)
            {
                result.Distance = GetDistanceFromLatLonInKm(latitude.Value, longitude.Value, Latitude.Value, Longitude.Value);
            }

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
        
        private double GetDistanceFromLatLonInKm(double lat1,
            double lon1,
            double lat2,
            double lon2) {
            var R = 6371d; // Radius of the earth in km
            var dLat = Deg2Rad(lat2 - lat1);  // deg2rad below
            var dLon = Deg2Rad(lon2 - lon1); 
            var a = 
                Math.Sin(dLat / 2d) * Math.Sin(dLat / 2d) +
                Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * 
                Math.Sin(dLon / 2d) * Math.Sin(dLon / 2d); 
            var c = 2d * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1d - a)); 
            var d = R * c; // Distance in km
            return d;
        }

        private double Deg2Rad(double deg) {
            return deg * (Math.PI / 180d);
        }
    }
}