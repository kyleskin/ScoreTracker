namespace ScoreTracker.WebApi.NHLScoreTracker.Models;

public sealed class Status
{
    public decimal Clock { get; set; }
    public string DisplayClock { get; set; } = string.Empty;
    public int Period { get; set; }
    public StatusType Type { get; set; } = new();
}