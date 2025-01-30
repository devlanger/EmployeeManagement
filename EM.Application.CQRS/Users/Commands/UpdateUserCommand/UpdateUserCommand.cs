using EM.Application.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Commands.UpdateUserCommand;

public class UpdateUserCommand : IRequest
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
    public string? PersonalIdNumber { get; set; }
    public string? City { get; set; }
    public string? SupervisorId { get; set; }
    public int? TeamId { get; set; }
    public IEnumerable<string>? SelectedRoles { get; set; }
}