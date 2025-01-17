using EM.Application.Abstract;
using EM.Application.Abstract.Services;
using EM.Core.Models;

namespace EM.Application.Concrete.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IDataProvider<Employee> _dataProvider;

    public EmployeeService(IDataProvider<Employee> _dataProvider)
    {
        this._dataProvider = _dataProvider;
    }

    public async Task<Employee> GetEmployeeAsync(int employeeId)
    {
        var data = await _dataProvider.GetAllAsync();
        return data.FirstOrDefault(e => e.Id.GetValueOrDefault() == employeeId);
    }

    public async Task<Employee> GetEmployeeWithSmallestSalaryAsync()
    {
        var data = await _dataProvider.GetAllAsync();
        return data.MinBy(x => x.Salary);
    }
}