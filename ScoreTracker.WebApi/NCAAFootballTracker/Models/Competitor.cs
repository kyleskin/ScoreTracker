namespace ScoreTracker.WebApi.NCAAFootballTracker.Models;

public sealed class Competitor
{
    public string HomeAway { get; set; } = string.Empty;
    public Team Team { get; set; } = new();
    public string Score { get; set; } = string.Empty;
}