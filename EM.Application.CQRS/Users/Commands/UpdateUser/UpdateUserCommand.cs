using MediatR;

namespace EM.Application.CQRS.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
    public string? PersonalIdNumber { get; set; }
    public string? City { get; set; }
    public int? SupervisorId { get; set; }
    public int? TeamId { get; set; }
    public IEnumerable<string>? SelectedRoles { get; set; }
}