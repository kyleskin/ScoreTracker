namespace ScoreTracker.WebApi.DTOs.EspnResponse;

public class EspnCompetitor
{
    public string HomeAway { get; set; } = string.Empty;
    public EspnTeam Team { get; set; } = new();
    public string Score { get; set; } = string.Empty;
}