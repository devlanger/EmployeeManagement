using EM.Application.Abstract.Services;
using MediatR;

namespace EM.Application.CQRS.Employee.Queries.GetEmployeeQuery;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Core.Models.Employee>
{
    private readonly IRepository<Core.Models.Employee> _employeeRepo;

    public GetEmployeeQueryHandler(IRepository<Core.Models.Employee> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }
    
    public async Task<Core.Models.Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var x = await _employeeRepo.GetByIdAsync(request.Id);
        return x;
    }
}