using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
        
        [ForeignKey("Appointment")]
        public int? AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        
        [Required]
        public string Detail { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        public DateTime DeliveryDate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}