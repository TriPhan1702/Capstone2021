using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.ServiceDTOs
{
    public class UpdateServiceResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
}