using Microsoft.AspNetCore.Identity;

namespace EM.Core.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? PersonalIdNumber { get; set; }
    
    public decimal Salary { get; set; }
    
    public int? TeamId { get; set; }
    
    public virtual Team Team { get; set; }
    
    public string? City { get; set; }

    public DateTimeOffset? Birthday { get; set; }
}