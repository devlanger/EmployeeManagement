using EM.Core.Models;
using MediatR;

namespace EM.Application.CQRS.Team.Queries.GetTeamQuery;

public class GetTeamQuery : IRequest, IRequest<Core.Models.Team>
{
    public int Id { get; set; }
}