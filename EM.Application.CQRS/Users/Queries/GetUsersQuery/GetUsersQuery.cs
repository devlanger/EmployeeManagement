using EM.Core.Models;
using MediatR;

namespace EM.Application.CQRS.User.Queries.GetUsersQuery;

public class GetUsersQuery : IRequest<IEnumerable<ApplicationUser>>
{
}