namespace ScoreTracker.WebApi.NBATracker.Models;

public sealed class Team
{
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ShortDisplayName { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string AlternateColor { get; set; } = string.Empty;
}