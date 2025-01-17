using EM.Application.Abstract.Services;
using EM.Core.Models;

namespace EM.Application.Concrete.Services;

public class BonusService : IBonusService
{
    public void GiveBonus(Employee employee, decimal amount)
    {
        var bonusAmount = employee.Salary * amount;
        employee.Salary = Math.Round(employee.Salary + bonusAmount, 2);
    }
}