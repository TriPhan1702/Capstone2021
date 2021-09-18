using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Data
{
    public class Seed
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            //Used to generate test user below
            const string testPassword = "Test123";
            const string adminRoleName = "Administrator";

            //Seed roles
            var roles = new List<AppRole>
            {
                new AppRole {Name = "Administrator"},
                new AppRole {Name = "Manager"},
                new AppRole {Name = "Employee"},
                new AppRole {Name = "Customer"}
            };

            foreach (var role in roles) await roleManager.CreateAsync(role);

            var users = new List<AppUser>
            {
                new AppUser {UserName = "comradewang"}
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, testPassword);
                await userManager.AddToRoleAsync(user, adminRoleName);
            }
        }
    }
}