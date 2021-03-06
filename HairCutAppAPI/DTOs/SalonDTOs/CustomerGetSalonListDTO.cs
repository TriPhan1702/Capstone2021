using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CustomerGetSalonListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}