namespace ScoreTracker.WebApi.NCAAFootballTracker.Models;

public sealed class StatusType
{
    public string State { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string ShortDetail { get; set; } = string.Empty;
}