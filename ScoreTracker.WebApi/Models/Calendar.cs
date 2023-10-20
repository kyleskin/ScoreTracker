namespace ScoreTracker.WebApi.Models;

public sealed class Calendar
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public List<CalendarEntry> Entries { get; set; } = new();
}