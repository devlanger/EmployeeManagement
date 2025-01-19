using EM.Core.Models;
using MediatR;

namespace EM.Application.CQRS.User.Queries.GetUserQuery;

public class GetUserQuery : IRequest, IRequest<ApplicationUser>
{
    public int Id { get; set; }
}