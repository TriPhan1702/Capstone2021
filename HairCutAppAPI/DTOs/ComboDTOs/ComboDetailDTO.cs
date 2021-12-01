using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.ComboDTOs
{
    public class ComboDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public long Price { get; set; }
        public string AvatarUrl { get; set; }
        public ICollection<ComboDetailServiceDTO> Services { get; set; }
    }

    public class ComboDetailServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
    }
}