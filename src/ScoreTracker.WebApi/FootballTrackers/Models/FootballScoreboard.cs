using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.FootballTrackers.Models;

public sealed class FootballScoreboard : Scoreboard
{
    public FootballSituation Situation { get; set; } = new();
}