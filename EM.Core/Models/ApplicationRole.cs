using Microsoft.AspNetCore.Identity;

namespace EM.Core.Models;

public class ApplicationRole : IdentityRole<int>
{
    public ApplicationRole()
    {
        
    }

    public ApplicationRole(string roleName) : base(roleName)
    {
        
    }
}