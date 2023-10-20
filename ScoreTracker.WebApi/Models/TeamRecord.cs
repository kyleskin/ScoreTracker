namespace ScoreTracker.WebApi.Models;

public sealed class TeamRecord
{
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}