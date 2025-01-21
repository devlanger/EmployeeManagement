using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Teams.Queries.GetTeamQuery;

public class GetTeamQuery(int id) : IRequest<TeamViewModel>
{
    public int Id { get; set; } = id;
}