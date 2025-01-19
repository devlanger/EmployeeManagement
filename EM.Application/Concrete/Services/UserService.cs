using EM.Application.Abstract.Services;
using EM.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.Concrete.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> GetUserAsync(string userId)
    {
        var data = await _userManager.Users.ToListAsync();
        var x = data.FirstOrDefault(e => e.Id == userId);
        return x;
    }

    public async Task<ApplicationUser> GetUserWithSmallestSalaryAsync()
    {
        var data = await _userManager.Users.ToListAsync();
        return data.MinBy(x => x.Salary);
    }
}