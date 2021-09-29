using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class ServicesStaffs
    {
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}