using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class CustomersCodes
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [ForeignKey("Code")]
        public int CodeId { get; set; }
        public PromotionalCode Code { get; set; }
        
        public int TimesUsed { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
    }
}