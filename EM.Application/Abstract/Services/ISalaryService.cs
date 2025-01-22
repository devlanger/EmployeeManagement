using EM.Application.Models;

namespace EM.Application.Abstract.Services;

public interface ISalaryService
{
    Task<IEnumerable<SalaryStatisticResponseModel>> GetEmployeeSalaryStatistics();
}