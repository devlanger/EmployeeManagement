using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.User.Queries.GetUsersQuery;

public class GetUsersQueryHandler(UserManager<ApplicationUser> employeeRepo) 
    : IRequestHandler<GetUsersQuery, IEnumerable<ApplicationUser>>
{
    public async Task<IEnumerable<ApplicationUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var x = await employeeRepo.Users
            .Include(x => x.Team)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return x;
    }
}