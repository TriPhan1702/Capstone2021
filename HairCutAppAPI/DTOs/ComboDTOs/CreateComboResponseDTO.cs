using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.ComboDTOs
{
    public class CreateComboResponseDTO
    {
        public int Id { get; set; }
        public CreateComboResponseServiceList Services { get; set; }
    }

    public class CreateComboResponseServiceList
    {
        public Dictionary<int, string> Services { get; set; }
    }
}