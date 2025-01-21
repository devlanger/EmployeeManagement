using EM.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Infrastructure.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider services)
    {
        var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await context.Database.EnsureCreatedAsync();

        if (!context.Roles.Any())
        {
            foreach (var role in IdentityConstants.AllRoles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        
        if (!context.Teams.Any())
        {
            var teams = new List<Team>()
            {
                new() { Name = "Team 1" },
                new() { Name = "Team 2" },
                new() { Name = "Team 3" },
            };

            await context.Teams.AddRangeAsync(teams);
            await context.SaveChangesAsync();
        }
        
        if (!context.Users.Any())
        {
            var adminUser = await userManager.FindByEmailAsync("admin@em.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                    { UserName = "admin@em.com", Email = "admin@em.com", FirstName = "John", LastName = "Doe", Salary = 100, TeamId = 1};
                await userManager.CreateAsync(adminUser, "Test!123");
                await userManager.AddToRolesAsync(adminUser, IdentityConstants.AllRoles);
            }

            var employeeUser = new ApplicationUser
                { UserName = "employee@em.com", Email = "employee@em.com", FirstName = "John", LastName = "Foe", Salary = 200, TeamId = 2};
            await userManager.CreateAsync(employeeUser, "Test!123");
            await userManager.AddToRoleAsync(employeeUser, IdentityConstants.EMPLOYEE_ROLE_NAME);

            var testerUser = new ApplicationUser
                { UserName = "tester@em.com", Email = "tester@em.com", FirstName = "John", LastName = "Goe", Salary = 200};
            await userManager.CreateAsync(testerUser, "Test!123");

        }
    }
}