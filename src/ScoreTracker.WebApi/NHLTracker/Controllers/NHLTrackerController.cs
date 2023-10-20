using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NHLTracker.Models;

namespace ScoreTracker.WebApi.NHLTracker.Controllers;

[Route("api/{controller}/{action}")]
[ApiController]
public class NHLTrackerController : ControllerBase
{
    private readonly IScoreboardService<NHLScoreboard> _nhlScoreboardService;

    public NHLTrackerController(IScoreboardService<NHLScoreboard> nhlScoreboardService)
    {
        _nhlScoreboardService = nhlScoreboardService;
    }

    [HttpGet]
    public async Task<NHLScoreboard> Scoreboard()
    {
        return await _nhlScoreboardService.GetTodaysScoreboardAsync();
    }

    [HttpGet]
    public async Task<NHLScoreboard> WeeklyScoreboard()
    {
        return await _nhlScoreboardService.GetThisWeeksScoreboardAsync();
    }
}