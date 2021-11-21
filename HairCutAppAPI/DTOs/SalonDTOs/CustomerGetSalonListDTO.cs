using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CustomerGetSalonListDTO
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}