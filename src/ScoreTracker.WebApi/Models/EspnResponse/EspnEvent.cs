namespace ScoreTracker.WebApi.Models.EspnResponse;

public abstract class EspnEvent
{
    public string Date { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    
}