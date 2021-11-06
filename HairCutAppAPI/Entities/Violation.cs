using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Violation
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Offender")]
        public int OffenderUserId { get; set; }
        public virtual AppUser Offender { get; set; }
        
        [Required]
        [ForeignKey("Appointment")]
        public int? AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        
        [Required]
        public int ViolationTypeId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
    }
}