namespace EM.Application.CQRS.Common.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string id) : base($"User with id {id} not found."){}
}