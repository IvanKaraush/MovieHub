using ExceptionsLibrary.Exceptions;

namespace FilmService.Application.Services.Exceptions;

public class FilmAlreadyExistException : AlreadyExistException
{
    public FilmAlreadyExistException()
    {
    }

    public FilmAlreadyExistException(string message) : base(message)
    {
    }

    public FilmAlreadyExistException(string message, Exception ex) : base(message, ex)
    {
    }
}