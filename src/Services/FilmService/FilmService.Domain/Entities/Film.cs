using Ardalis.GuardClauses;
using GuardExtensions;

namespace FilmService.Domain.Entities;

public class Film
{
    public Guid Id
    {
        get => _id;
        private set
        {
            Guard.Against.IsNullOrDefault(value, nameof(value));
            _id = value;
        }
    }
    private Guid _id;

    public string Title
    {
        get => _title;
        private set
        {
            Guard.Against.SpecialCharacters(value, nameof(value));
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
            Guard.Against.SpecialCharacters(value, nameof(value));
            _url = value;
        }
    }

    private string _url = null!;

    public Film(string title, string description, string url)
    {
        Title = title;
        Description = description;
        Url = url;
    }
}