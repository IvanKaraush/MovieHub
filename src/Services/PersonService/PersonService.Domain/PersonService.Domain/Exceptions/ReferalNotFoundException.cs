using ExceptionsLibrary.Exceptions;

namespace Domain.Exceptions;

public class ReferalNotFoundException : NotFoundException
{
    public ReferalNotFoundException()
    {
    }

    public ReferalNotFoundException(string message) : base(message)
    {
    }

    public ReferalNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}