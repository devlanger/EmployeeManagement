using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Team.Queries.GetTeamsQuery;

public class GetTeamsQuery : IRequest<IEnumerable<TeamViewModel>>
{
}