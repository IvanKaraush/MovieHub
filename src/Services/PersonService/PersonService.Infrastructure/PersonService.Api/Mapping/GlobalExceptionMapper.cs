using System;
using ExceptionsLibrary.Interfaces;

namespace PersonService.Api.Mapping;

public class GlobalExceptionMapper : IGlobalExceptionMapper
{
    public Exception Map(Exception ex)
    {
        return ex;
    }
}