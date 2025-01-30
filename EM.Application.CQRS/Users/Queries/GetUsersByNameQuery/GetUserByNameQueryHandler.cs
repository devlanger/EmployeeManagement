using AutoMapper;
using EM.Application.Models;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Users.Queries.GetUsersByNameQuery;

public class GetUsersQueryByNameHandler : IRequestHandler<GetUsersByNameQuery, IEnumerable<ApplicationUserResponseModel>>
{
    private readonly UserManager<ApplicationUser> _employeeRepo;
    private readonly IMapper _mapper;

    public GetUsersQueryByNameHandler(UserManager<ApplicationUser> employeeRepo, IMapper mapper)
    {
        _employeeRepo = employeeRepo;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ApplicationUserResponseModel>> Handle(GetUsersByNameQuery request, CancellationToken cancellationToken)
    {
        var x = await _employeeRepo.Users
            .Where(u => (u.FirstName + " " + u.LastName).ToLower()
                .Contains(request.Name.ToLower()))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
        
        var response = x.Select(y => 
            _mapper.Map(y, new ApplicationUserResponseModel()));
        
        return response;
    }
}