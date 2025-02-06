using EM.Application.Abstract.Services;
using EM.Application.Models;
using EM.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.Concrete.Services;

public class SalaryService : ISalaryService
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly (int, int)[] _salaryGroups =
    {
        (0, 1000),
        (1000, 3000),
        (3000, 100000)
    };

    public SalaryService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<SalaryStatisticResponseModel>> GetEmployeeSalaryStatistics()
    {
        var response = new List<SalaryStatisticResponseModel>();

        foreach (var salaryGroup in _salaryGroups)
        {
            var amount = await _userManager.Users
                .Where(x => x.Salary >= salaryGroup.Item1 && x.Salary <= salaryGroup.Item2)
                .AsNoTracking()
                .CountAsync();

            response.Add(new SalaryStatisticResponseModel(amount, salaryGroup.Item1, salaryGroup.Item2));
        }

        return response;
    }
}