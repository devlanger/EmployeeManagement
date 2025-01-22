using EM.Application.Abstract.Services;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EM.Application.CQRS.Salaries.Commands.GiveSalaryBonusCommand;

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
        var employee = await _userManager.FindByIdAsync(request.EmployeeId);
        
        if (employee == null)
            throw new Exception($"User with id {request.EmployeeId} not found");
        
        _bonusService.GiveBonus(employee, 0.2m);
        
        await _userManager.UpdateAsync(employee);
    }
}