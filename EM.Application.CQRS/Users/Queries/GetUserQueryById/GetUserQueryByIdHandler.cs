using AutoMapper;
using EM.Application.CQRS.Common.Exceptions;
using EM.Application.Models;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EM.Application.CQRS.Users.Queries.GetUserQueryById;

public class GetUserQueryByIdHandler : IRequestHandler<GetUserByIdQuery, ApplicationUserResponseModel>
{
    private readonly UserManager<ApplicationUser> _employeeRepo;
    private readonly IMapper _mapper;

    public GetUserQueryByIdHandler(UserManager<ApplicationUser> employeeRepo, IMapper mapper)
    {
        _employeeRepo = employeeRepo;
        _mapper = mapper;
    }
    
    public async Task<ApplicationUserResponseModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _employeeRepo.FindByIdAsync(request.Id);
        
        if (user == null)
            throw new UserNotFoundException(request.Id);
        
        var applicationUserResponseModel = new ApplicationUserResponseModel();
        _mapper.Map(user, applicationUserResponseModel);
        return applicationUserResponseModel;
    }
}