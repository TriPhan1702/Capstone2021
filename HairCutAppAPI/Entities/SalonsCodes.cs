using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class SalonsCodes
    {
        [ForeignKey("Customer")]
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        
        [ForeignKey("Code")]
        public int CodeId { get; set; }
        public PromotionalCode Code { get; set; }
    }
}