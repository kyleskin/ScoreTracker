namespace ScoreTracker.WebApi.NHLTracker.Models;

public sealed class NHLScoreboard
{
    public List<Event> Events { get; set; } = new();
}