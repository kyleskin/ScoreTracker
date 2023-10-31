using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.MLBTracker.Models;

public sealed class BaseballScoreboard : Scoreboard
{
    public BaseballSituation Situation { get; set; } = new();
}