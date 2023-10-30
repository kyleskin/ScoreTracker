using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.DTOs;

public class ScoreboardResponse
{
    public List<Scoreboard> Scoreboards { get; set; } = new();
}