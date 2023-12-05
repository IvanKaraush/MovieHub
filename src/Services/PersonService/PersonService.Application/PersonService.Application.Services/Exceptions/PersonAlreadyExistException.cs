using ExceptionsLibrary.Exceptions;

namespace PersonService.Application.Services.Exceptions;

public class PersonAlreadyExistException : AlreadyExistException
{
    public PersonAlreadyExistException()
    {
    }

    public PersonAlreadyExistException(string message) : base(message)
    {
    }

    public PersonAlreadyExistException(string message, Exception ex) : base(message, ex)
    {
    }
}