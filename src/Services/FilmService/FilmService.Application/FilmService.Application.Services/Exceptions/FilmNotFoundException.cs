using ExceptionsLibrary.Exceptions;

namespace FilmService.Application.Services.Exceptions;

public class FilmNotFoundException : NotFoundException
{
    public FilmNotFoundException()
    {
    }

    public FilmNotFoundException(string message) : base(message)
    {
    }

    public FilmNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}