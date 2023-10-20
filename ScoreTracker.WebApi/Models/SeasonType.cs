namespace ScoreTracker.WebApi.Models;

public sealed class SeasonType
{
    public string Id { get; set; } = string.Empty;
    public int Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
}