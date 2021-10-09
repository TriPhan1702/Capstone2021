using System;

namespace HairCutAppAPI.DTOs.ServiceDTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdated { get; set; }
        public decimal Price { get; set; }
    }
}