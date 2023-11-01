namespace ScoreTracker.WebApi.DTOs.EspnResponse;

public class EspnFootballSituation : EspnSituation
{
    public int Down { get; set; }
    public int YardLine { get; set; }
    public int Distance { get; set; }
    public string DownDistanceText { get; set; } = string.Empty;
    public string ShortDownDistanceText { get; set; } = string.Empty;
    public string PossessionText { get; set; } = string.Empty;
    public bool IsRedZone { get; set; }
    public int HomeTimeouts { get; set; }
    public int AwayTimeouts { get; set; }
}