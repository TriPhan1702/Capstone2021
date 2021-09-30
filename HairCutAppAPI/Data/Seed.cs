using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
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
                new AppRole {Name = GlobalVariables.AdministratorRole},
                new AppRole {Name = GlobalVariables.ManagerRole},
                new AppRole {Name = GlobalVariables.StaffRole},
                new AppRole {Name = GlobalVariables.CustomerRole}
            };

            foreach (var role in roles) await roleManager.CreateAsync(role);

            var users = new List<AppUser>
            {
                new AppUser {UserName = "comradewang", Status = "Active"}
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, testPassword);
                await userManager.AddToRoleAsync(user, adminRoleName);
            }
        }
    }
}