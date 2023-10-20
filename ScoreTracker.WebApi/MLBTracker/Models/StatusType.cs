namespace ScoreTracker.WebApi.MLBTracker.Models;

public sealed class StatusType
{
    public bool Completed { get; set; }
    public string Detail { get; set; } = string.Empty;
}