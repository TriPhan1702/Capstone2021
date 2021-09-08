using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace HairCutAPI.Data
{
    public class Seed
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            //Seed roles
            var roles = new List<AppRole>()
            {
                new AppRole{Name = "Administrator"},
                new AppRole{Name = "Manager"},
                new AppRole{Name = "Employee"},
                new AppRole{Name = "Customer"},
                new AppRole{Name = "NewCustomer"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}