using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class AppointmentRating
    {
        [Key] 
        public int Id { get; set; }
        
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        [Required]
        public int Rating { get; set; }
        
        [MaxLength(500)]
        public string RatingComment { get; set; }
        
        
    }
}