namespace EM.Application.CQRS.Users.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string id) : base($"User with id {id} not found")
    {
    }
}