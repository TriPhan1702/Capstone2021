using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.DTOs;

namespace HairCutAppAPI.Entities
{
    public class Staff
    {
        //One-to-One relationship with User
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public AppUser User { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        
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

        public StaffDetailDTO ToStaffDetailDTO()
        {
            return new StaffDetailDTO()
            {
                FullName = FullName,
                Description = Description,
                StaffType = StaffType,
                Email = User.Email,
                SalonId = SalonId,
                UserId = User.Id,
                StaffId = Id,
                AvatarUrl = User.AvatarUrl,
                PhoneNumber = User.PhoneNumber
            };
        }
    }
}