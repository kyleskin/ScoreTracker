using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.FootballTrackers.Models;

public class FootballScoreboard : Scoreboard
{
    public FootballSituation Situation { get; set; } = new();
}