namespace ScoreTracker.WebApi.Models;

public sealed class Athlete
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public List<Link> Links { get; set; } = new();
    public string Headshot { get; set; } = string.Empty;
    public string Jersey { get; set; } = string.Empty;
    public Position Position { get; set; } = new();
    public Team Team { get; set; } = new();
    public bool Active { get; set; }
}