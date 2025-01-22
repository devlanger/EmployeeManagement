using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Queries.GetUsersQuery;

public class GetUsersQuery : IRequest<IEnumerable<ApplicationUserResponseModel>>
{
}