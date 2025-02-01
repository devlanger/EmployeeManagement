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
        var users = await employeeRepo.Users
            .Include(x => x.Team)
            .Include(x => x.Supervisor)
            .Select(x => GetUsersQueryHandler.GetMapping(mapper, x))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
        
        if(!users.Any())
            return Enumerable.Empty<ApplicationUserResponseModel>();
        
        return users;
    }

    private static ApplicationUserResponseModel GetMapping(IMapper mapper, ApplicationUser user)
    {
        var result = mapper.Map<ApplicationUserResponseModel>(user);
        result.SupervisorName = user.SupervisorId is not null ? $"{user.Supervisor.FirstName} {user.Supervisor.LastName}" : null;
        return result;
    }
}