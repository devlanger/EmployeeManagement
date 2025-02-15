using MediatR;

namespace EM.Application.CQRS.Salaries.Commands.GiveSalaryBonus;

public class GiveSalaryBonusCommand(int employeeId) : IRequest
{
    public int EmployeeId { get; set; } = employeeId;
}