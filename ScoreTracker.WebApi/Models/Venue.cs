namespace ScoreTracker.WebApi.Models;

public sealed class Venue
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
    public int Capacity { get; set; }
    public bool Indoor { get; set; }
}