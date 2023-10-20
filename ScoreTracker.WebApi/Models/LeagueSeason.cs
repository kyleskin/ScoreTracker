namespace ScoreTracker.WebApi.Models;

public sealed class LeagueSeason
{
    public int Year { get; set; }
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public SeasonType Type { get; set; } = new();
}