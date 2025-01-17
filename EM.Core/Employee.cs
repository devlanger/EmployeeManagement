namespace EM.Core;

public class Employee
{
    public ulong EmployeeId { get; set; }
    public double Salary { get; set; }

    public Employee(ulong employeeId, uint salary)
    {
        EmployeeId = employeeId;
        Salary = salary;
    }
}