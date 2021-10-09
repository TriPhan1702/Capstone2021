using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.ComboDTOs
{
    public class UpdateComboResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Duration { get; set; }
        public ICollection<UpdateComboResponseServiceDTO> Services { get; set; }
    }

    public class UpdateComboResponseServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}