namespace ScoreTracker.WebApi.NBAScoreTracker.Models;

public sealed class NBAScoreboard
{
    public List<Event> Events { get; set; } = new();
}