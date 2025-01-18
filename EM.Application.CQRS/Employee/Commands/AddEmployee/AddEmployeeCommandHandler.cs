using EM.Application.Abstract.Services;
using MediatR;

namespace EM.Application.CQRS.Employee.Commands.AddEmployee;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly IRepository<Core.Models.Employee> _employeeRepo;

    public AddEmployeeCommandHandler(IRepository<Core.Models.Employee> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }
    
    public async Task Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var newEmployee = new Core.Models.Employee()
        {
            PersonalIdNumber = request.PersonalIdNumber,
            Salary = request.Salary
        };
        
        await _employeeRepo.AddAsync(newEmployee);
    }
}