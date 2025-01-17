using System.Text;
using EM.Application.Services.Abstract;
using EM.Core.Models;
using Microsoft.Extensions.Options;

namespace EM.Application.Concrete.DataProviders;

public class TxtFileDataProvider(IOptions<TxtDataSettings> options) : IDataProvider<Employee>
{
    private readonly TxtDataSettings _settings = options.Value;

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        var result = ReadLines().Result
            .Select(ParseSalaryField);
        
        return Task.FromResult(result);
    }
    
    public async Task SaveAllAsync(IEnumerable<Employee> employees)
    {
        var x = employees.Select(SerializeEmployee).ToList();

        await File.WriteAllLinesAsync(_settings.FilePath, x);
    }
    
    private Task<IEnumerable<string>> ReadLines()
    {
        return Task.FromResult(File.ReadLines(_settings.FilePath));
    }

    private string SerializeEmployee(Employee employee)
    {
        return $"{employee.Id};{employee.PersonalIdNumber};{employee.Salary}";
    }

    private Employee ParseSalaryField(string eachSalaryRow)
    {
        var salaryDataFields = eachSalaryRow.Split(";");

        var requiredFieldsAmount = 3;

        if (salaryDataFields.Length < requiredFieldsAmount)
            throw new Exception($"Amount of data fields in text is less than {requiredFieldsAmount}");

        if (!int.TryParse(salaryDataFields[0], out var id))
            throw new ArgumentException("Issue reading salary data field 0");

        if (string.IsNullOrEmpty(salaryDataFields[1]))
            throw new ArgumentException("Issue reading salary data field 1");
        
        if (!decimal.TryParse(salaryDataFields[2], out var salary))
            throw new ArgumentException("Issue reading salary data field 2");

        var personalIdNumber = salaryDataFields[1];
        
        return new Employee() 
        {
            Id = id,
            PersonalIdNumber = personalIdNumber,
            Salary = salary
        };
    }
}