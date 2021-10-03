using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class CrewDetail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Crew")]
        public int CrewId { get; set; }
        [Required] 
        public Crew Crew { get; set; }
        
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        [Required] 
        public Staff Staff { get; set; }
    }
}