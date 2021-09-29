using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public override string SecurityStamp { get; set; }
        
        [Required]
        [MinLength(1), MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public ICollection<AppUserRole> UserRole { get; set; }

        //Numeric only, length 10
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Must be 10 digits")]
        public override string PhoneNumber { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }
    }
}