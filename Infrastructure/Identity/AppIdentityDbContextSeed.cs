using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Constants;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext appIdentityDbContext, UserManager<ApplicationUser> userManager)
        {

            if (appIdentityDbContext.Database.IsSqlServer())
            {
                appIdentityDbContext.Database.Migrate();
            }

            var defaultUser = new ApplicationUser {FirstName = "John", LastName = "Smith", UserName = "demouser@transpApp.com", Email = "demouser@transpApp.com"};
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_USER_PASSWORD);
            var isAdmin = false;
            await userManager.AddClaimAsync(defaultUser, new Claim("IsAdmin", isAdmin.ToString()));

            var adminUser = new ApplicationUser {FirstName = "admin", LastName = "admin", UserName = "admin@transpApp.com", Email = "admin@transpApp.com" };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_ADMIN_PASSWORD);
            isAdmin = true;
            await userManager.AddClaimAsync(adminUser, new Claim("IsAdmin", isAdmin.ToString()));

            if (appIdentityDbContext.Users.Count() < 3)
            {
                var employeeUser = new ApplicationUser { FirstName = "John", LastName = "Smith", UserName = "johnSmith", Email = "johnSmith@transpApp.com" };
                await userManager.CreateAsync(employeeUser, AuthorizationConstants.DEFAULT_EMPLOYEE_PASSWORD);
                var isEmployee = true; ;
                await userManager.AddClaimAsync(employeeUser, new Claim("IsEmployee", isEmployee.ToString()));
            }
        }
    }
}
