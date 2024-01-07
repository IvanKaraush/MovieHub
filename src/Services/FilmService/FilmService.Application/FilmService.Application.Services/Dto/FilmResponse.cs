namespace FilmService.Application.Services.Dto;

public class FilmResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string Url { get; init; } = null!;
}