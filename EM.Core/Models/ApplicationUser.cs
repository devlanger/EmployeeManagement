using Microsoft.AspNetCore.Identity;

namespace EM.Core.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? City { get; set; }

    public DateTimeOffset? Birthday { get; set; }
}