namespace ScoreTracker.WebApi.NCAAFootball.Models;

public sealed class NCAAFootballScoreboard
{
    public List<Event> Events { get; set; } = new();
}