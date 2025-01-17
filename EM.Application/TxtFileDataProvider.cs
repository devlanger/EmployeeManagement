using EM.Core;
using Microsoft.Extensions.Options;

namespace EM.Application;

public class TxtFileDataProvider : IDataProvider<Employee>
{
    private string _dataFilePath = "test_data.txt";

    public TxtFileDataProvider(IOptions<TxtDataSettings> options)
    {
        
    }
    
    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        var result = ReadLines().Result
            .Select(ParseSalaryField);
        
        return Task.FromResult(result);
    }

    private Task<IEnumerable<string>> ReadLines()
    {
        return Task.FromResult(File.ReadLines(_dataFilePath));
    }

    private Employee ParseSalaryField(string eachSalaryRow)
    {
        var salaryDataFields = eachSalaryRow.Split(";");

        var requiredFieldsAmount = 2;

        if (salaryDataFields.Length < requiredFieldsAmount)
            throw new Exception($"Amount of data fields in text is less than {requiredFieldsAmount}");

        if (!ulong.TryParse(salaryDataFields[0], out var employeeId))
            throw new ArgumentException("Issue reading salary data field 0");

        if (!uint.TryParse(salaryDataFields[1], out var employeeSalary))
            throw new ArgumentException("Issue reading salary data field 1");

        return new Employee(employeeId, employeeSalary);
    }
}