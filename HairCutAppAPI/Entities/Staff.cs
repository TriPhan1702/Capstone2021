using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Staff
    {
        //One-to-One relationship with User
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public AppUser User { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        [Required]
        public int AppointmentsNumber { get; set; }
        
        [Required]
        public int SuccessfulAppointmentsNumber { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string StaffType { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        //Can be null
        [ForeignKey("Salon")]
        public int? SalonId { get; set; }
        public virtual Salon Salon { get; set; }
        
        public ICollection<WorkSlot> WorkSlots { get; set; }
        
        public ICollection<CrewDetail> CrewDetails { get; set; }
    }
}