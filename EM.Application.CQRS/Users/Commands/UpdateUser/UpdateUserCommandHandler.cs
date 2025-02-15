using EM.Application.Abstract.Services;
using EM.Application.Concrete.Services;
using EM.Application.CQRS.Common.Exceptions;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    UserManager<ApplicationUser> usersManager, 
    IRoleService roleService,
    IAuditLogService auditLogService)
    : IRequestHandler<UpdateUser.UpdateUserCommand>
{
    public async Task Handle(UpdateUser.UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await usersManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken: cancellationToken);

        if (user == null)
            throw new UserNotFoundException(request.Id);

        user.Email = request.Email;
        user.PersonalIdNumber = request.PersonalIdNumber;
        user.City = request.City;
        user.Salary = request.Salary;
        user.TeamId = request.TeamId;
        user.SupervisorId = request.SupervisorId;

        //Add locking
        if (request.SelectedRoles != null)
        {
            await roleService.UpdateUserRolesAsync(user, request.SelectedRoles.ToList());
        }

        await usersManager.UpdateAsync(user);
        
        auditLogService.Log(new UpdateUserAuditLog()
        {
            UserId = user.Id,
            City = user.City,
            Email = user.Email,
            Salary = user.Salary,
            Username = user.Email,
        });
    }
}