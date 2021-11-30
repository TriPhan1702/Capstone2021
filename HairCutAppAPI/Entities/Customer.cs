using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.DTOs.CustomerDTO;

namespace HairCutAppAPI.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        //One-to-One relationship with User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public bool EmailConfirmed { get; set; }
        public bool PhoneConfirmed { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        public virtual ICollection<Appointment> Appointments { get; set; }

        public CustomerDetailDTO ToCustomerDetailDTO()
        {
            return new CustomerDetailDTO()
            {
                FullName = FullName,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
                UserId = User.Id,
                CustomerId = Id,
                AvatarUrl = User.AvatarUrl,
                Status = User.Status
            };
        }
    }
}