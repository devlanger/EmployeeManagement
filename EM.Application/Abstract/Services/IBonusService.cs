using EM.Core.Models;

namespace EM.Application.Abstract.Services;

public interface IBonusService
{
    void GiveBonus(Employee employee, decimal amount);
}