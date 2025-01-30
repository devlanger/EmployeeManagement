using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;

namespace EM.Application.Models;

public class ApplicationUserUpdateViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
        
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; }
        
    [Required(ErrorMessage = "First Name is required.")]
    public string LastName { get; set; }
        
    public string? City { get; set; }
    
    public int? TeamId { get; set; }
        
    public DateTimeOffset? Birthday { get; set; }

    [Ignore] public HashSet<string> SelectedRoles { get; set; } = new HashSet<string>();

    // [Range(18, 99, ErrorMessage = "Age must be between 18 and 99.")]
    // public int Age { get; set; }

    //public List<string> Roles { get; set; }
}