using System.Collections.Generic;
using HairCutAppAPI.DTOs.ComboDTOs;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CustomerGetSalonDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public List<ComboDetailDTO> ComboDetailDTOs { get; set; }
    }
}