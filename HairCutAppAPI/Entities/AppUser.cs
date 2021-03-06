using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HairCutAppAPI.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Entities
{
    public class AppUser : IdentityUser<int>
    {
        [Required]
        public override string UserName { get; set; }
        [Required]
        public override string NormalizedUserName { get; set; }

        [Required]
        public override string Email { get; set; }
        [Required]
        public override string NormalizedEmail { get; set; }

        [Required]
        public override string PasswordHash { get; set; }
        
        [Required]
        [MinLength(1), MaxLength(20)]
        public string Status { get; set; }
        
        public virtual ICollection<AppUserRole> UserRole { get; set; }
        
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        
        public Device Device { get; set; }

        //Numeric only, length 10
        [StringLength(10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Must be 10 digits")]
        public override string PhoneNumber { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }

        public GetUserListResponseDTO ToGetUserListResponseDTO()
        {
            var result = new GetUserListResponseDTO
            {
                Id = Id,
                UserName = UserName,
                Email = Email,
                Status = Status,
                AvatarUrl = AvatarUrl,
                PhoneNumber = PhoneNumber,
                UserRoles = UserRole.Select(role => role.Role.Name).ToList()
            };

            return result;
        }
    }
}