using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.Entities
{
    public class Param
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        public int NumberValue { get; set; }
        public string TextValue { get; set; }
    }
}