namespace ScoreTracker.WebApi.NFLTracker.Models;

public sealed class Situation
{
    public int Down { get; set; }
    public int YardLine { get; set; }
    public int Distance { get; set; }
    public string DownDistanceText { get; set; } = string.Empty;
    public string ShortDownDistanceText { get; set; } = string.Empty;
    public string PossessionText { get; set; } = string.Empty;
    public bool IsRedZone { get; set; }
    public int HomeTimeOuts { get; set; }
    public int AwayTimeOuts { get; set; }
    public string Possession { get; set; } = string.Empty;
}