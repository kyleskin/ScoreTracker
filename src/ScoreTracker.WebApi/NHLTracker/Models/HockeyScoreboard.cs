using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.NHLTracker.Models;

public sealed class HockeyScoreboard : Scoreboard
{
    public HockeySituation Situation { get; set; } = new();
}