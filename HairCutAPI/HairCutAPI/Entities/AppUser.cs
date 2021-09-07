﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HairCutAPI.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> UserRole { get; set; }
    }
}
