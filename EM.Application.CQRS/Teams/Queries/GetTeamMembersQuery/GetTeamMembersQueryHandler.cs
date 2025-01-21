using EM.Application.Abstract.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Teams.Queries.GetTeamMembersQuery;

public class GetTeamMembersQueryHandler : IRequestHandler<GetTeamMembersQuery, IEnumerable<string>>
{
    private readonly IRepository<Core.Models.Team> _teamRepo;

    public GetTeamMembersQueryHandler(IRepository<Core.Models.Team> teamRepo)
    {
        _teamRepo = teamRepo;
    }
    
    public async Task<IEnumerable<string>> Handle(GetTeamMembersQuery request, CancellationToken cancellationToken)
    {
        var x = await _teamRepo.Query()
            .Include(t => t.Members)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);
        
        if (x == null)
            throw new Exception($"Team with id {request.Id} not found");
        
        var members = x.Members.Select(y => $"{y.FirstName}{y.LastName}");

        return members ?? Enumerable.Empty<string>();
    }
}