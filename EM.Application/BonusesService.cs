using EM.Core;

namespace EM.Application;

public class BonusesService
{
    public void GiveBonus(Employee employee, double amount)
    {
        var bonusAmount = employee.Salary * amount;
        employee.Salary = employee.Salary + bonusAmount;
    }
}