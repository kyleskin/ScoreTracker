using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.FootballTrackers.NFLTracker.Services;
using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.FootballTrackers.NFLTracker.Controllers;

[ApiController]
[Route("api/{controller}/{action}")]
public class NFLTrackerController : ControllerBase
{
    private readonly IScoreboardService<NFLScoreboardService> _scoreboardService;

    public NFLTrackerController(IScoreboardService<NFLScoreboardService> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<ScoreboardResponse> Scoreboard()
    {
        return await _scoreboardService.GetTodaysScoreboardAsync();
    }

    [HttpGet]
    public async Task<ScoreboardResponse> WeeklyScoreboard()
    {
        return await _scoreboardService.GetThisWeeksScoreboardAsync();
    }
}