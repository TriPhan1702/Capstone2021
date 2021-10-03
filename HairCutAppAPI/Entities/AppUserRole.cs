using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }

        public AppRole Role { get; set; }
    }
}