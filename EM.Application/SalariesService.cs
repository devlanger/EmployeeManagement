namespace EM.Core;

public class SalariesService
{
    private readonly string _dataFilePath;
    private readonly Dictionary<ulong, Employee> _employeeSalaries;

    public SalariesService(string dataFilePath)
    {
        _dataFilePath = dataFilePath;
    }

    public Employee GetEmployee(ulong employeeId)
    {
        return _employeeSalaries.TryGetValue(employeeId, out var employeeSalary) 
            ? employeeSalary : null;
    }

    public Employee GetEmployeeWithSmallestSalary()
    {
        return _employeeSalaries.Values.MinBy(x => x.Salary);
    }
}