using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class CustomersCodes
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        
        [ForeignKey("Code")]
        public int CodeId { get; set; }
        public virtual PromotionalCode Code { get; set; }
        
        public int TimesUsed { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
    }
}