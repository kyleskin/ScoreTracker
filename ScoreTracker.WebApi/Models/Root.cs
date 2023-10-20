namespace ScoreTracker.WebApi.Models;

public sealed class Root
{
    public List<League> Leagues { get; set; } = new();
    public List<Event> Events { get; set; } = new();
}