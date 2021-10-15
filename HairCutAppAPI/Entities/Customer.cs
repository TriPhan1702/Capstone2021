using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        //One-to-One relationship with User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public AppUser User { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        public ICollection<Appointment> Appointments { get; set; }
    }
}