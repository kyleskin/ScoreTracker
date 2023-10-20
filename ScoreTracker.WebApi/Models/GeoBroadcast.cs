namespace ScoreTracker.WebApi.Models;

public sealed class GeoBroadcast
{
    public GeoBroadcastType Type { get; set; } = new();
    public Market Market { get; set; } = new();
    public string Lang { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
}