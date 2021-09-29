using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("TargetUser")]
        public int TargetUserId { get; set; }
        public AppUser TargetUser { get; set; }
        
        [ForeignKey("SecondaryUser")]
        public int? SecondaryUserId { get; set; }
        public virtual AppUser SecondaryUser { get; set; }
        
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Type { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}