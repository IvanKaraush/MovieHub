﻿namespace FilmService.Application.Services.Dto;

public class CreateFilmRequest
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string Url { get; init; } = null!;
}