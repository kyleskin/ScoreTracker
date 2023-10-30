using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NBATracker.Models;
using ScoreTracker.WebApi.NBATracker.Services;

namespace ScoreTracker.WebApi.NBATracker.Controllers;

[Route("api/{controller}/{action}")]
[ApiController]
public class NBATrackerController : ControllerBase
{
    private readonly IScoreboardService<NBAScoreboardService> _nbaScoreboardService;

    public NBATrackerController(IScoreboardService<NBAScoreboardService> nbaScoreboardService)
    {
        _nbaScoreboardService = nbaScoreboardService;
    }

    [HttpGet]
    public async Task<NBAScoreboard> Scoreboard()
    {
        // return await _nbaScoreboardService.GetTodaysScoreboardAsync();
        return new();
    }

    [HttpGet]
    public async Task<NBAScoreboard> WeeklyScoreboard()
    {
        // return await _nbaScoreboardService.GetThisWeeksScoreboardAsync();
        return new();
    }
    
}