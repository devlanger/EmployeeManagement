using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.User.Queries.SearchUserQuery;

public class SearchUserQuery : IRequest<IEnumerable<UserSearchViewModel>>
{
    public string Query { get; set; }
}