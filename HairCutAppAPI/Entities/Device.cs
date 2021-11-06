using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
        
        public string DeviceId { get; set; }
        
        [Required]
        public string DeviceToken { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
    }
}