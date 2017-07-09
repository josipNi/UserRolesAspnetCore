using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserTable.Server.Entities;

namespace UserTable.Server.Data
{
    public static class DbInitializer
    {
        public static async Task<bool> InitializeDatabase(IServiceProvider serviceProvider, int userAmount)
        {

            Profico_DB_Context _seedContext = serviceProvider.GetRequiredService<Profico_DB_Context>();
            
                _seedContext.Database.Migrate(); // creates db if it does not exist

                if (_seedContext.Users.Any() || _seedContext.Roles.Any() || _seedContext.RoleClaims.Any())
                    return false;

            return await CreateUsers(serviceProvider, userAmount);             

        }

        public static async Task<bool> CreateUsers(IServiceProvider serviceProvider, int userAmount)
        {
            try
            {
             
                string[] all_roles = new string[] { "Admin", "User", "Guest" };
               
                bool areRolesCreated = await CreateRoles(serviceProvider, all_roles);

                if (!areRolesCreated)
                    return false;

                UserManager<ApplicationUser> _seedUserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                for (int i = 0; i < userAmount; i++)
                {
                    int randomI = new Random().Next(0, all_roles.Length);
                    string[] roles = all_roles.Take(randomI).ToArray();
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = "firstName" + i,
                        LastName = "lastName" + i,
                        UserName = "profico" + i,
                        NormalizedUserName = "PROFICO" + i,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        Email = "josip.nikolic01@gmail.com" + i,
                        NormalizedEmail = "JOSIP.NIKOLIC01@GMAIL.COM",
                        TwoFactorEnabled = false,
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                    };
                    var password = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = password.HashPassword(user, "testtest12323!");
                    await _seedUserManager.CreateAsync(user);

                    IdentityResult rolesAdded = await AssignRoles(serviceProvider, user.Id, roles);
                    if (!rolesAdded.Succeeded)
                        return false;
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static async Task<bool> CreateRoles(IServiceProvider serviceProvider, string[] roles)
        {
            try
            {
                RoleManager<IdentityRole> _seedRoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                foreach (string role in roles)
                {
                    await _seedRoleManager.CreateAsync(new IdentityRole(role));
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string id, string[] roles)
        {
            try
            {
                UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                var result = await _userManager.AddToRolesAsync(user, roles);
                return result;
            }
            catch
            {
                return null;
            }
            
        }
    }
}