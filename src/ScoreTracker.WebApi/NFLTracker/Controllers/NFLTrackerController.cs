using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NFLTracker.Models;

namespace ScoreTracker.WebApi.NFLTracker.Controllers;

[ApiController]
[Route("api/{controller}/{action}")]
public class NFLTrackerController : ControllerBase
{
    private readonly IScoreboardService<NFLScoreboard> _scoreboardService;

    public NFLTrackerController(IScoreboardService<NFLScoreboard> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<NFLScoreboard> Scoreboard()
    {
        return await _scoreboardService.GetTodaysScoreboardAsync();
    }

    [HttpGet]
    public async Task<NFLScoreboard> WeeklyScoreboard()
    {
        return await _scoreboardService.GetThisWeeksScoreboardAsync();
    }
}