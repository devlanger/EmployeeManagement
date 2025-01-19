using EM.Application.Abstract.Services;
using EM.Application.Models;
using EM.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.User.Queries.SearchUserQuery;

public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, IEnumerable<UserSearchViewModel>>
{
    private readonly IRepository<ApplicationUser> _employeeRepo;

    public SearchUserQueryHandler(IRepository<ApplicationUser> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    public async Task<IEnumerable<UserSearchViewModel>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Query))
            return Enumerable.Empty<UserSearchViewModel>();

        var suggestions = await _employeeRepo.Query()
            .Where(e => e.FirstName.Contains(request.Query) || e.LastName.Contains(request.Query))
            .Select(e => new UserSearchViewModel() { Id = e.Id, FullName = e.FirstName + " " + e.LastName })
            .ToListAsync(cancellationToken: cancellationToken);

        return suggestions;
    }
}