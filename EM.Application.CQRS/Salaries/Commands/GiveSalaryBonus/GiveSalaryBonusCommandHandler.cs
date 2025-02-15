using EM.Application.Abstract.Services;
using EM.Application.CQRS.Common.Exceptions;
using EM.Core.AuditLogs;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Salaries.Commands.GiveSalaryBonus;

public class GiveSalaryBonusCommandHandler(
    UserManager<ApplicationUser> userManager,
    IBonusService bonusService,
    IAuditLogService auditLogService)
    : IRequestHandler<GiveSalaryBonusCommand>
{
    public async Task Handle(GiveSalaryBonusCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.EmployeeId, cancellationToken: cancellationToken);
        
        if (user == null)
            throw new UserNotFoundException(request.EmployeeId);

        bonusService.GiveBonus(user, 0.2m);

        try
        {
            await userManager.UpdateAsync(user);
            auditLogService.Log(new UpdateUserSalaryAuditLog()
            {
                UserId = user.Id,
                Salary = user.Salary
            });
        }
        catch
        {
            throw new UserUpdateException(user.Id);
        }
    }
}