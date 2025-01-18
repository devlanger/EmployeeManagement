using EM.Core.Models;

namespace EM.Application.Abstract.Services;

public interface IRoleService
{
    Task UpdateUserRolesAsync(ApplicationUser user, List<string> newRoles);
}