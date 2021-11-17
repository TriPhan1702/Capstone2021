using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class AppointmentDetail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        
        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        
        [Required]
        public DateTime StartTime { get; set; }
        
        [Required]
        public DateTime EndTime { get; set; }
        
        [Required]
        public bool IsDoneByStylist { get; set; }
        
        [Required]
        public int ServiceOrder { get; set; }
        
        public virtual ICollection<WorkSlot> WorkSlots { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}