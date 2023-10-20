namespace ScoreTracker.WebApi.Models;

public sealed class CalendarEntry
{
    public string Label { get; set; } = string.Empty;
    public string AlternateLabel { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
}