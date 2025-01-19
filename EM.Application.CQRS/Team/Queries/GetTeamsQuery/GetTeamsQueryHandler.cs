using EM.Application.Abstract.Services;
using EM.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Team.Queries.GetTeamsQuery;

public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IEnumerable<TeamViewModel>>
{
    private readonly IRepository<Core.Models.Team> _teamRepo;

    public GetTeamsQueryHandler(IRepository<Core.Models.Team> teamRepo)
    {
        _teamRepo = teamRepo;
    }
    
    public async Task<IEnumerable<TeamViewModel>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
    {
        var x = await _teamRepo.Query()
            .Select(x => new TeamViewModel(){ Id = x.Id.GetValueOrDefault(), Name = x.Name, MembersCount = x.Members.Count})
            .ToListAsync(cancellationToken: cancellationToken);
        
        return x;
    }
}