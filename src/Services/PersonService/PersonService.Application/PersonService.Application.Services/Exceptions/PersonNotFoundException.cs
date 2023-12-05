using ExceptionsLibrary.Exceptions;

namespace PersonService.Application.Services.Exceptions;

public class PersonNotFoundException : NotFoundException
{
    public PersonNotFoundException()
    {
    }

    public PersonNotFoundException(string message) : base(message)
    {
    }

    public PersonNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}