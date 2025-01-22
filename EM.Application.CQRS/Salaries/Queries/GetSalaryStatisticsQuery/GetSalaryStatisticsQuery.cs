using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Salaries.Queries.GetSalaryStatisticsQuery;

public class GetSalaryStatisticsQuery : IRequest<IEnumerable<SalaryStatisticResponseModel>>
{
    
}