using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HairCutAPI.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRole { get; set; }
    }
}
