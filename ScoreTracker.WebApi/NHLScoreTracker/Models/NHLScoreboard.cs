namespace ScoreTracker.WebApi.NHLScoreTracker.Models;

public sealed class NHLScoreboard
{
    public List<Event> Events { get; set; } = new();
}