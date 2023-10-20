namespace ScoreTracker.WebApi.Models;

public sealed class Group
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public bool IsConference { get; set; }
}