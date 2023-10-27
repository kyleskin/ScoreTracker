using System.Collections.Specialized;

namespace ScoreTracker.WebApi.MLBTracker.Models;

public sealed class Competition
{
    public string Date { get; set; } = string.Empty;
    public Status Status { get; set; } = new();
    public List<Competitor> Competitors { get; set; } = new();
}