namespace HairCutAppAPI.DTOs.SalonDTOs
{
    public class AdvancedGetSalonResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdate { get; set; }
    }
}