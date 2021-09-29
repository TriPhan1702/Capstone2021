using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class CombosServices
    {
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo Combo { get; set; }
        
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}