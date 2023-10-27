using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Models;

namespace ScoreTracker.WebApi.MLBTracker.Controllers;

[ApiController]
[Route("api/{controller}/{action}")]
public class MLBTrackerController : ControllerBase
{
    private readonly IScoreboardService<MLBScoreboard> _scoreboardService;

    public MLBTrackerController(IScoreboardService<MLBScoreboard> scoreboardService)
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