using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NCAAFootballTracker.Models;

namespace ScoreTracker.WebApi.NCAAFootballTracker.Controllers;

[ApiController]
[Route("/api/{controller}/{action}")]
public class NCAAFootballTrackerController : ControllerBase
{
    private readonly IScoreboardService<NCAAFootballScoreboard> _scoreboardService;

    public NCAAFootballTrackerController(IScoreboardService<NCAAFootballScoreboard> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<NCAAFootballScoreboard> Scoreboard()
    {
        return await _scoreboardService.GetTodaysScoreboardAsync();
    }

    [HttpGet]
    public async Task<NCAAFootballScoreboard> WeeklyScoreboard()
    {
        return await _scoreboardService.GetThisWeeksScoreboardAsync();
    }
}