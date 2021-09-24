using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public override string NormalizedUserName { get; set; }

        public ICollection<AppUserRole> UserRole { get; set; }

        //Numeric only, length 10
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Must be 10 digits")]
        public override string PhoneNumber { get; set; }
    }
}