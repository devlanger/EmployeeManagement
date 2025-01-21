using MediatR;

namespace EM.Application.CQRS.Teams.Queries.GetTeamMembersQuery;

public class GetTeamMembersQuery(int id) : IRequest<IEnumerable<string>>
{
    public int Id { get; set; } = id;
}