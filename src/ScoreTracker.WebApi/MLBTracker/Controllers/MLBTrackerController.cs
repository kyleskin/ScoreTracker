using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Services;

namespace ScoreTracker.WebApi.MLBTracker.Controllers;

[ApiController]
[Route("api/{controller}/{action}")]
public class MLBTrackerController : ControllerBase
{
    private readonly IScoreboardService<MLBScoreboardService> _scoreboardService;

    public MLBTrackerController(IScoreboardService<MLBScoreboardService> scoreboardService)
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