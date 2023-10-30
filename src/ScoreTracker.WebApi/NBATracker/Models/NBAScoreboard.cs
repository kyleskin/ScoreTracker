using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.NBATracker.Models;

public sealed class NBAScoreboard : Scoreboard
{
    public NBASituation Situation { get; set; } = new();
}