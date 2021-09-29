using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class AppointmentsServices
    {
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}