namespace ScoreTracker.WebApi.NCAAFootballTracker.Models;

public sealed class NCAAFootballScoreboard
{
    public List<Event> Events { get; set; } = new();
}