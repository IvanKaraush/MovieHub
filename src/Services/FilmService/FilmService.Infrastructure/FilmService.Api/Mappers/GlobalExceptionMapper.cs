using ExceptionsLibrary.Interfaces;

namespace FilmService.Api.Mappers;

public class GlobalExceptionMapper : IGlobalExceptionMapper
{
    public Exception Map(Exception ex)
    {
        return ex;
    }
}