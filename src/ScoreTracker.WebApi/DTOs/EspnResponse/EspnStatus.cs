namespace ScoreTracker.WebApi.DTOs.EspnResponse;

public class EspnStatus
{
    public decimal Clock { get; set; }
    public string DisplayClock { get; set; } = string.Empty;
    public int Period { get; set; }
    public EspnStatusType Type { get; set; } = new();
}