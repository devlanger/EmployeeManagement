using MediatR;

namespace EM.Application.CQRS.Salaries.Commands.GiveSalaryBonusCommand;

public class GiveSalaryBonusCommand(string employeeId) : IRequest
{
    public string EmployeeId { get; set; } = employeeId;
}