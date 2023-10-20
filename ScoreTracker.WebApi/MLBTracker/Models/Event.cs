namespace ScoreTracker.WebApi.MLBTracker.Models;

public sealed class Event
{
    public string Date { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public List<Competition> Competitions { get; set; } = new();
}