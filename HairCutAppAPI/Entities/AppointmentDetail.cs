using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class AppointmentDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo Combo { get; set; }
        
        [ForeignKey("Crew")]
        public int? CrewId { get; set; }
        public Crew Crew { get; set; }
        
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}