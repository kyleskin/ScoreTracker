namespace ScoreTracker.WebApi.NBATracker.Models;

public sealed class NBAScoreboard
{
    public List<Event> Events { get; set; } = new();
}