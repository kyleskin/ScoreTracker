namespace ScoreTracker.WebApi.Models;

public sealed class EventSeason
{
    public int Year { get; set; }
    public int Type { get; set; }
    public string Slug { get; set; } = string.Empty;
}