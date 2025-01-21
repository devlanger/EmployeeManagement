using MediatR;

namespace EM.Application.CQRS.User.Commands.AddUser;

public class AddEmployeeCommand : IRequest
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string PersonalIdNumber { get; set; }
    
    public decimal Salary { get; set; }
}