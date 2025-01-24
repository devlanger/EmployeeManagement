using AutoMapper;
using EM.Application.Models;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EM.Application.CQRS.Users.Queries.GetUserQuery;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUserResponseModel>
{
    private readonly UserManager<ApplicationUser> _employeeRepo;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(UserManager<ApplicationUser> employeeRepo, IMapper mapper)
    {
        _employeeRepo = employeeRepo;
        _mapper = mapper;
    }
    
    public async Task<ApplicationUserResponseModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var x = await _employeeRepo.FindByIdAsync(request.Id);
        var applicationUserResponseModel = new ApplicationUserResponseModel();
        _mapper.Map(x, applicationUserResponseModel);
        return applicationUserResponseModel;
    }
}