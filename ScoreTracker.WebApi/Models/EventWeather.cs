namespace ScoreTracker.WebApi.Models;

public sealed class EventWeather
{
    public string DisplayValue { get; set; } = string.Empty;
    public int Temperature { get; set; }
    public int HighTemperature { get; set; }
    public string ConditionId { get; set; } = string.Empty;
    public Link Link { get; set; } = new();
}