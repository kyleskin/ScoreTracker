using ScoreTracker.WebApi.Models.EspnResponse;

namespace ScoreTracker.WebApi.Models;

public class Competitor
{
    public string HomeAway { get; set; } = string.Empty;
    public EspnTeam Team { get; set; } = new();
    public string Score { get; set; } = string.Empty;
}