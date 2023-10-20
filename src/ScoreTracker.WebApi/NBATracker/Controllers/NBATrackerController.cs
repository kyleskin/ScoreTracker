using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NBATracker.Models;

namespace ScoreTracker.WebApi.NBATracker.Controllers;

[Route("api/{controller}/{action}")]
[ApiController]
public class NBATrackerController : ControllerBase
{
    private readonly IScoreboardService<NBAScoreboard> _nbaScoreboardService;

    public NBATrackerController(IScoreboardService<NBAScoreboard> nbaScoreboardService)
    {
        _nbaScoreboardService = nbaScoreboardService;
    }

    [HttpGet]
    public async Task<NBAScoreboard> Scoreboard()
    {
        return await _nbaScoreboardService.GetTodaysScoreboardAsync();
    }

    [HttpGet]
    public async Task<NBAScoreboard> WeeklyScoreboard()
    {
        return await _nbaScoreboardService.GetThisWeeksScoreboardAsync();
    }
}