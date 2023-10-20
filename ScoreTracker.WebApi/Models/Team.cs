namespace ScoreTracker.WebApi.Models;

public sealed class Team
{
    public string Id { get; set; } = string.Empty;
    public string UId { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ShortDisplayName { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string AlternateColor { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public TeamVenue Venue { get; set; } = new();
    public List<Link> Links { get; set; } = new();
    public string Logo { get; set; } = string.Empty;
    public string ConferenceId { get; set; } = string.Empty;
}