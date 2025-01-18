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

        var roles = new[] 
        { 
            IdentityConstants.ADMIN_ROLE_NAME, 
            IdentityConstants.EMPLOYEE_ROLE_NAME 
        };
        
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
            adminUser = new ApplicationUser { UserName = "admin@em.com", Email = "admin@em.com", FirstName = "John", LastName = "Doe" };
            await userManager.CreateAsync(adminUser, "Test!123");
            await userManager.AddToRoleAsync(adminUser, IdentityConstants.ADMIN_ROLE_NAME);
        }
        
        var employeeUser = new ApplicationUser { UserName = "employee@em.com", Email = "employee@em.com", FirstName = "John", LastName = "Doe"  };
        await userManager.CreateAsync(employeeUser, "Test!123");
        await userManager.AddToRoleAsync(employeeUser, IdentityConstants.EMPLOYEE_ROLE_NAME);

        if (!context.Employees.Any())
        {
            var employees = new List<Employee>()
            {
                new() { PersonalIdNumber = "123123123", Salary = 1230 },
                new() { PersonalIdNumber = "039243234", Salary = 2730 },
                new() { PersonalIdNumber = "336233134", Salary = 5405 },
            };
            
            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }
    }
}