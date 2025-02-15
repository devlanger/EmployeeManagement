using EM.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.Extensions;

public static class UserExtensions
{
    public static async Task<ApplicationUser?> FindByIdAsync(this UserManager<ApplicationUser> userManager, int id)
    {
        return await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}