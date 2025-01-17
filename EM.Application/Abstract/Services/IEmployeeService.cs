using EM.Core.Models;

namespace EM.Application.Abstract.Services;

public interface IEmployeeService
{
    Task<Employee> GetEmployeeAsync(int employeeId);
    
    Task<Employee> GetEmployeeWithSmallestSalaryAsync();
}