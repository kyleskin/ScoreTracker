namespace ScoreTracker.WebApi.Models;

public sealed class Odds
{
    public OddsProvider Provider { get; set; } = new();
    public string Details { get; set; } = string.Empty;
    public decimal OverUnder { get; set; }
}