using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Customer
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
        
        public ICollection<Appointment> Appointments { get; set; }
    }
}