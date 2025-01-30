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

        //var currentUpdatedAt = employee.UpdatedAt;
        _bonusService.GiveBonus(employee, 0.2m);

        try
        {
            // if (employee.UpdatedAt != currentUpdatedAt)
            // {
            //     throw new Exception("The employee record has been modified by another user. Please try again.");
            // }
            //
            // employee.UpdatedAt = DateTimeOffset.Now;
            await _userManager.UpdateAsync(employee);
        }
        catch
        {
            throw new Exception("An error occurred while updating the employee.");
        }
    }
}