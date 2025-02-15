namespace EM.Application.Models;

public class ApplicationUserResponseModel
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? PersonalIdNumber { get; set; }
    
    public decimal Salary { get; set; }
    
    public string? City { get; set; }
    
    public int? SupervisorId { get; set; }
    
    public string? SupervisorName { get; set; }
    
    public int? TeamId { get; set; }

    public DateTimeOffset? Birthday { get; set; }
}