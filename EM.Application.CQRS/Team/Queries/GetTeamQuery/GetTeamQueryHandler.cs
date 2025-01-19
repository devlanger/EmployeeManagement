using EM.Application.Abstract.Services;
using MediatR;

namespace EM.Application.CQRS.Team.Queries.GetTeamQuery;

public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, Core.Models.Team>
{
    private readonly IRepository<Core.Models.Team> _teamRepo;

    public GetTeamQueryHandler(IRepository<Core.Models.Team> teamRepo)
    {
        _teamRepo = teamRepo;
    }
    
    public async Task<Core.Models.Team> Handle(GetTeamQuery request, CancellationToken cancellationToken)
    {
        var x = await _teamRepo.GetByIdAsync(request.Id);
        return x;
    }
}