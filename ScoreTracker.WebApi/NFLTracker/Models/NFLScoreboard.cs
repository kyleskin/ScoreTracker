namespace ScoreTracker.WebApi.NFLTracker.Models;

public sealed class NFLScoreboard
{
    public List<Event> Events { get; set; } = new();
}