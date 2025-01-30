using EM.Application.Abstract.Services;
using EM.Application.Models;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.User.Queries.SearchUserQuery;

public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, IEnumerable<UserSearchViewModel>>
{
    private readonly UserManager<ApplicationUser> _employeeRepo;

    public SearchUserQueryHandler(UserManager<ApplicationUser> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    public async Task<IEnumerable<UserSearchViewModel>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Query))
            return Enumerable.Empty<UserSearchViewModel>();

        var lowerQuery = request.Query.ToLower();
        
        var suggestions = await _employeeRepo.Users
            .Where(e => e.FirstName.ToLower().Contains(lowerQuery) || e.LastName.ToLower().Contains(lowerQuery))
            .Select(e => new UserSearchViewModel() { Id = e.Id, FullName = e.FirstName + " " + e.LastName })
            .Take(10)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        if (!suggestions.Any())
            return Enumerable.Empty<UserSearchViewModel>();
        
        return suggestions;
    }
}
