using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ECommerce.Identity.API.Seed
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAndClaimsAsync(
            RoleManager<IdentityRole> roleManager)
        {
            // Create Roles
            if (await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await roleManager.CreateAsync(adminRole);

                await roleManager.AddClaimAsync(adminRole, new Claim("Permission", "Products.Create"));
                await roleManager.AddClaimAsync(adminRole, new Claim("Permission", "Products.Update"));
                await roleManager.AddClaimAsync(adminRole, new Claim("Permission", "Products.Delete"));
                await roleManager.AddClaimAsync(adminRole, new Claim("Permission", "Orders.Manage"));
            }

            if (await roleManager.RoleExistsAsync("Customer"))
            {
                var customerRole = new IdentityRole("Customer");
                await roleManager.CreateAsync(customerRole);

                await roleManager.AddClaimAsync(customerRole, new Claim("Permission", "Orders.Create"));
                await roleManager.AddClaimAsync(customerRole, new Claim("Permission", "Orders.View"));
            }
        }
    }
}
