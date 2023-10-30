using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.FootballTrackers.NCAAFootballTracker.Services;
using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.FootballTrackers.NCAAFootballTracker.Controllers;

[ApiController]
[Route("/api/{controller}/{action}")]
public class NCAAFootballTrackerController : ControllerBase
{
    private readonly IScoreboardService<NCAAFootballScoreboardService> _scoreboardService;

    public NCAAFootballTrackerController(IScoreboardService<NCAAFootballScoreboardService> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<IActionResult> Scoreboard()
    {
        return Ok(await _scoreboardService.GetTodaysScoreboardAsync());
    }

    [HttpGet]
    public async Task<IActionResult> WeeklyScoreboard()
    {
        return Ok(await _scoreboardService.GetThisWeeksScoreboardAsync());
    }
}