using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.BasketballTrackers.Models;

public sealed class BasketballScoreboard : Scoreboard
{
    public BasketballSituation Situation { get; set; } = new();
}