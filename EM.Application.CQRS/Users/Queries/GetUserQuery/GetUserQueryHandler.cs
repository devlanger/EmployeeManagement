using EM.Application.Abstract.Services;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EM.Application.CQRS.User.Queries.GetUserQuery;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _employeeRepo;

    public GetUserQueryHandler(UserManager<ApplicationUser> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }
    
    public async Task<ApplicationUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var x = await _employeeRepo.FindByIdAsync(request.Id);
        return x;
    }
}