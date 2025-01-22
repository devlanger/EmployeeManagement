using AutoMapper;
using EM.Application.Models;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Users.Queries.GetUsersQuery;

public class GetUsersQueryHandler(UserManager<ApplicationUser> employeeRepo, IMapper mapper) 
    : IRequestHandler<GetUsersQuery, IEnumerable<ApplicationUserResponseModel>>
{
    public async Task<IEnumerable<ApplicationUserResponseModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var x = await employeeRepo.Users
            .Include(x => x.Team)
            .Select(x => mapper.Map(x, new ApplicationUserResponseModel()))
            .ToListAsync(cancellationToken: cancellationToken);
        
        return x;
    }
}