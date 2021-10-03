using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class ComboDetail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo Combo { get; set; }
        
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}