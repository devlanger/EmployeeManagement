using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Queries.GetUsersByNameQuery;

public class GetUsersByNameQuery : IRequest<IEnumerable<ApplicationUserResponseModel>>
{
    public string Name { get; set; }
}