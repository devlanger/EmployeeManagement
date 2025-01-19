using EM.Core.Models;

namespace EM.Application.Abstract.Services;

public interface IUserService
{
    Task<ApplicationUser> GetUserAsync(string userId);
    
    Task<ApplicationUser> GetUserWithSmallestSalaryAsync();
}