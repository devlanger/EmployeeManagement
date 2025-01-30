using EM.Application.Abstract.Services;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Users.Queries.GetEmployeeMaxSalary;

public class GetEmployeeMaxSalaryHandler(UserManager<ApplicationUser> usersRepository)
    : IRequestHandler<GetEmployeeMaxSalary, decimal>
{
    public async Task<decimal> Handle(GetEmployeeMaxSalary request, CancellationToken cancellationToken)
    {
        var result = await usersRepository.Users
            .MaxAsync(x => x.Salary, cancellationToken: cancellationToken);
        return result;
    }
}