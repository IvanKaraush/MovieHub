using ExceptionsLibrary.Exceptions;

namespace Domain.Exceptions;

public class ReferralAlreadyExistException : AlreadyExistException
{
    public ReferralAlreadyExistException()
    {
    }

    public ReferralAlreadyExistException(string message) : base(message)
    {
    }

    public ReferralAlreadyExistException(string message, Exception ex) : base(message, ex)
    {
    }
}