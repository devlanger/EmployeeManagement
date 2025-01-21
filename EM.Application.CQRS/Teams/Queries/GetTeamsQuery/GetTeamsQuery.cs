using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Teams.Queries.GetTeamsQuery;

public class GetTeamsQuery : IRequest<IEnumerable<TeamViewModel>>
{
}