using EM.Application.Abstract.Services;
using EM.Core.Models;
using MediatR;

namespace EM.Application.CQRS.User.Queries.GetUserQuery;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUser>
{
    private readonly IRepository<ApplicationUser> _employeeRepo;

    public GetUserQueryHandler(IRepository<ApplicationUser> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }
    
    public async Task<ApplicationUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var x = await _employeeRepo.GetByIdAsync(request.Id);
        return x;
    }
}