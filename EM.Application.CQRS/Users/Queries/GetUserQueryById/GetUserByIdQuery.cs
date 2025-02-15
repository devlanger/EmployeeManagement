using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Queries.GetUserQueryById;

public class GetUserByIdQuery : IRequest<ApplicationUserResponseModel>
{
    public int Id { get; set; }
}