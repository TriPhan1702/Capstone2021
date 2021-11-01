using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class CreateSalonResponseDTO
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }
        
        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}