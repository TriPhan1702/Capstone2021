using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CustomerGetSalonListResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public double? Distance { get; set; }
    }
}