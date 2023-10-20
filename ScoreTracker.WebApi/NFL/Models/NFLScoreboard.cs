namespace ScoreTracker.WebApi.NFL.Models;

public sealed class NFLScoreboard
{
    public List<Event> Events { get; set; } = new();
}