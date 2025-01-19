using EM.Application.Abstract.Services;
using EM.Core.Models;
using MediatR;

namespace EM.Application.CQRS.User.Commands.AddUser;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly IRepository<ApplicationUser> _employeeRepo;

    public AddEmployeeCommandHandler(IRepository<ApplicationUser> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }
    
    public async Task Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var newEmployee = new ApplicationUser()
        {
            PersonalIdNumber = request.PersonalIdNumber,
            Salary = request.Salary
        };
        
        await _employeeRepo.AddAsync(newEmployee);
    }
}