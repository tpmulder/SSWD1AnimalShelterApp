using AnimalShelter.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.AuthServer.Configuration
{
    public static class IdentityDataSeeder
    {
        private readonly static List<ASRole> _seededRoles = new List<ASRole>();

        public static void SeedData(UserManager<ASUser> userManager, RoleManager<ASRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ASUser> userManager) =>
            _seededRoles.ForEach(e => SeedUser(userManager, new ASUser(
                e.Name, 
                $"test{_seededRoles.IndexOf(e)}@test.com", 
                e.Name, 
                "test", 
                new DateTime(1998, 1, 5)),
                e.Name
            ));

        public static void SeedRoles(RoleManager<ASRole> roleManager) =>
            new List<ASRole>
            {
                new ASRole("RegisteredUser", "Access to personal account"),
                new ASRole("Volunteer", "Access to backoffice"),
                new ASRole("Admin", "Access to everything")
            }
            .ForEach(e => SeedRole(roleManager, e));

        private static void SeedRole(RoleManager<ASRole> roleManager, ASRole role)
        {
            if (!roleManager.RoleExistsAsync(role.Name).Result)
            {
                var result = roleManager.CreateAsync(role).Result;

                if (result.Succeeded)
                    _seededRoles.Add(role);
            }
        }

        private static void SeedUser(UserManager<ASUser> userManager, ASUser user, string userRole)
        {
            if (userManager.FindByNameAsync(user.Email).Result == null)
            {
                var result = userManager.CreateAsync(user, "test123").Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, userRole).Wait();
            }
        }
    }
}
