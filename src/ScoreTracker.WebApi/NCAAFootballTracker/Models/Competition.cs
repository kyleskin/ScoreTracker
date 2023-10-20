namespace ScoreTracker.WebApi.NCAAFootballTracker.Models;

public sealed class Competition
{
    public List<Competitor> Competitors { get; set; } = new();
    public Status Status { get; set; } = new();
}