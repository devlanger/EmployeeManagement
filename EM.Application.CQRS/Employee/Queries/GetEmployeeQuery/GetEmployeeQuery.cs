using MediatR;

namespace EM.Application.CQRS.Employee.Queries.GetEmployeeQuery;

public class GetEmployeeQuery : IRequest, IRequest<Core.Models.Employee>
{
    public int Id { get; set; }
}