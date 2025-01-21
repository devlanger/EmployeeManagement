using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EM.Application.CQRS.User.Commands.AddUser;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly UserManager<ApplicationUser> _employeeRepo;

    public AddEmployeeCommandHandler(UserManager<ApplicationUser> employeeRepo)
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
        
        await _employeeRepo.CreateAsync(newEmployee);
    }
}