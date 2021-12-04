using System.Collections.Generic;
using HairCutAppAPI.DTOs.ComboDTOs;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class GetSalonDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}