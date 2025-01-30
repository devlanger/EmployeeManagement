using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Queries.GetUserQueryById;

public class GetUserByIdQuery : IRequest<ApplicationUserResponseModel>
{
    public string Id { get; set; }
}