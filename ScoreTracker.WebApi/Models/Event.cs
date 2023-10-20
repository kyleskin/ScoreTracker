namespace ScoreTracker.WebApi.Models;

public sealed class Event
{
    public string Id { get; set; } = string.Empty;
    public string UId { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public EventSeason Season { get; set; } = new();
    public EventWeek Week { get; set; } = new();
    public List<Competition> Competitions { get; set; } = new();
    public List<Link> Links { get; set; } = new();
    public EventWeather Weather { get; set; } = new();
    public Status Status { get; set; } = new();
}