using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public virtual  ICollection<AppUserRole> UserRole { get; set; }
    }
}