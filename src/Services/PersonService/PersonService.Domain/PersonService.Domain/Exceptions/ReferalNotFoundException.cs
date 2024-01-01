using ExceptionsLibrary.Exceptions;

namespace Domain.Exceptions;

public class ReferralNotFoundException : NotFoundException
{
    public ReferralNotFoundException()
    {
    }

    public ReferralNotFoundException(string message) : base(message)
    {
    }

    public ReferralNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}