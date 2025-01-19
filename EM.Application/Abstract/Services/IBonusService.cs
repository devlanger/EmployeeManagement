using EM.Core.Models;

namespace EM.Application.Abstract.Services;

public interface IBonusService
{
    void GiveBonus(ApplicationUser employee, decimal amount);
}