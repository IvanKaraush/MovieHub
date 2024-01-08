using Ardalis.GuardClauses;
using FilmService.Domain.Extensions;
using GuardExtensions;

namespace FilmService.Domain.Entities;

public class Film
{
    public Guid Id
    {
        get => _id;
        private init
        {
            Guard.Against.Default(value, nameof(value));
            _id = value;
        }
    }

    private readonly Guid _id;

    public string Title
    {
        get => _title;
        private set
        {
            Guard.Against.Default(value, nameof(value));
            _title = value;
        }
    }

    private string _title = null!;

    public string Description
    {
        get => _description;
        private set
        {
            Guard.Against.SpecialCharacters(value, nameof(value));
            _description = value;
        }
    }

    private string _description = null!;

    public string Url
    {
        get => _url;
        private set
        {
            Guard.Against.IsCorrectUrl(value, nameof(value));
            _url = value;
        }
    }

    private string _url = null!;

    public Film(Guid id, string title, string description, string url)
    {
        Id = id;
        Title = title;
        Description = description;
        Url = url;
    }

    public void Update(string title, string description, string url)
    {
        Title = title;
        Description = description;
        Url = url;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Film film)
        {
            return film.Id == Id;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Title, Description);
    }
}