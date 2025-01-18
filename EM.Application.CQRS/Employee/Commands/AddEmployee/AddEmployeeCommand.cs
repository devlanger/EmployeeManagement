using MediatR;

namespace EM.Application.CQRS.Employee.Commands.AddEmployee;

public class AddEmployeeCommand : IRequest
{
    public string PersonalIdNumber { get; set; }
    
    public decimal Salary { get; set; }
}