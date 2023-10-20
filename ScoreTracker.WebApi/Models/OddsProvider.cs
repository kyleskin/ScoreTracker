namespace ScoreTracker.WebApi.Models;

public sealed class OddsProvider
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Priority { get; set; }
}