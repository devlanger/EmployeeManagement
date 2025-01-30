using EM.Application.Abstract.Services;
using EM.Application.CQRS.Users.Exceptions;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Users.Commands.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly UserManager<ApplicationUser> _usersManager;
    private readonly IRoleService _roleService;
    
    public UpdateUserCommandHandler(UserManager<ApplicationUser> usersManager, IRoleService roleService)
    {
        _usersManager = usersManager;
        _roleService = roleService;
    }
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken: cancellationToken);

        if (user == null)
            throw new UserNotFoundException(request.Id);

        user.Email = request.Email;
        user.PersonalIdNumber = request.PersonalIdNumber;
        user.City = request.City;
        user.Salary = request.Salary;
        user.TeamId = request.TeamId;

        //Add locking
        if (request.SelectedRoles != null)
        {
            await _roleService.UpdateUserRolesAsync(user, request.SelectedRoles.ToList());
        }
        await _usersManager.UpdateAsync(user);
    }
}