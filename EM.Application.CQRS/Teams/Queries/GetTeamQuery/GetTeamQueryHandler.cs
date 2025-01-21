using EM.Application.Abstract.Services;
using EM.Application.Models;
using EM.Core.Models;
using MediatR;

namespace EM.Application.CQRS.Teams.Queries.GetTeamQuery;

public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, TeamViewModel>
{
    private readonly IRepository<Team> _teamRepo;

    public GetTeamQueryHandler(IRepository<Team> teamRepo)
    {
        _teamRepo = teamRepo;
    }

    public async Task<TeamViewModel> Handle(GetTeamQuery request, CancellationToken cancellationToken)
    {
        var x = await _teamRepo.GetByIdAsync(request.Id);
        return new TeamViewModel()
        {
            Id = x.Id.GetValueOrDefault(),
            Name = x.Name,
            MembersCount = x.Members.Count,
        };
    }
}