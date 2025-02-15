using EM.Application.Abstract.Services;
using EM.Application.CQRS.Common.Exceptions;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Salaries.Commands.GiveSalaryBonus;

public class GiveSalaryBonusCommandHandler : IRequestHandler<GiveSalaryBonusCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IBonusService _bonusService;

    public GiveSalaryBonusCommandHandler(
        UserManager<ApplicationUser> userManager, 
        IBonusService bonusService)
    {
        _userManager = userManager;
        _bonusService = bonusService;
    }
    
    public async Task Handle(GiveSalaryBonusCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.EmployeeId, cancellationToken: cancellationToken);
        
        if (user == null)
            throw new UserNotFoundException(request.EmployeeId);

        _bonusService.GiveBonus(user, 0.2m);

        try
        {
            await _userManager.UpdateAsync(user);
        }
        catch
        {
            throw new UserUpdateException(user.Id);
        }
    }
}