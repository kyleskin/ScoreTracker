namespace ScoreTracker.WebApi.Models;

public sealed class Ticket
{
    public string Summary { get; set; } = string.Empty;
    public int NumberAvailable { get; set; }
    public List<Link> Links { get; set; } = new();
}