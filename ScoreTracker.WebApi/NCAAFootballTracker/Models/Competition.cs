namespace ScoreTracker.WebApi.NCAAFootball.Models;

public sealed class Competition
{
    public List<Competitor> Competitors { get; set; } = new();
    public Status Status { get; set; } = new();
}