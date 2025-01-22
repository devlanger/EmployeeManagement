using EM.Application.Abstract.Services;
using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Salaries.Queries.GetSalaryStatisticsQuery;

public class GetSalaryStatisticsQueryHandler : IRequestHandler<GetSalaryStatisticsQuery, IEnumerable<SalaryStatisticResponseModel>>
{
    private readonly ISalaryService _salaryService;

    public GetSalaryStatisticsQueryHandler(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }
    
    public async Task<IEnumerable<SalaryStatisticResponseModel>> Handle(GetSalaryStatisticsQuery request, CancellationToken cancellationToken)
    {
        var x = await _salaryService.GetEmployeeSalaryStatistics();
        return x;
    }
}