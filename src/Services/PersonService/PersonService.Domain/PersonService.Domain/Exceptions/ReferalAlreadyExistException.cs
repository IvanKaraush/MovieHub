using ExceptionsLibrary.Exceptions;

namespace Domain.Exceptions;

public class ReferalAlreadyExistException : AlreadyExistException
{
    public ReferalAlreadyExistException()
    {
    }

    public ReferalAlreadyExistException(string message) : base(message)
    {
    }

    public ReferalAlreadyExistException(string message, Exception ex) : base(message, ex)
    {
    }
}