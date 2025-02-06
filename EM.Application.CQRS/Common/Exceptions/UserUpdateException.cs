namespace EM.Application.CQRS.Common.Exceptions;

public class UserUpdateException : Exception
{
    public UserUpdateException(string id) : base($"An error occurred while updating the user with id {id}.")
    {
        
    }
}