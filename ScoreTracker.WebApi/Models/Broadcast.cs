namespace ScoreTracker.WebApi.Models;

public sealed class Broadcast
{
    public string Market { get; set; } = string.Empty;
    public List<string> Names { get; set; } = new();
}