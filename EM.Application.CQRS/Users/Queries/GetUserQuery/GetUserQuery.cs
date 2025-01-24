using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Queries.GetUserQuery;

public class GetUserQuery : IRequest<ApplicationUserResponseModel>
{
    public string Id { get; set; }
}