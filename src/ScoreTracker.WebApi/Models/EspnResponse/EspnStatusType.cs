namespace ScoreTracker.WebApi.Models.EspnResponse;

public class EspnStatusType
{
    public string State { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string ShortDetail { get; set; } = string.Empty;
}