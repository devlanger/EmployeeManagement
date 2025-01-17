using EM.Core.Models;

namespace EM.Application.Concrete.Services;

public class BonusesService
{
    public void GiveBonus(Employee employee, decimal amount)
    {
        var bonusAmount = employee.Salary * amount;
        employee.Salary = employee.Salary + bonusAmount;
    }
}