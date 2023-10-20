namespace ScoreTracker.WebApi.Models;

public sealed class Leader
{
    public string DisplayValue { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public Athlete Athlete { get; set; } = new();
    public Team Team { get; set; } = new();
}