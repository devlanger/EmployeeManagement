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

        var roles = new[] { "Admin", "User" };
        foreach (var role in roles)
        {
            var roleExist = await roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        
        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminUser == null)
        {
            adminUser = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
            var result = await userManager.CreateAsync(adminUser, "Test!123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        if (!context.Employees.Any())
        {
            await context.Employees.AddAsync(new Employee()
            {
                PersonalIdNumber = "123123123",
                Salary = 1230
            });

            await context.SaveChangesAsync();
        }
    }
}