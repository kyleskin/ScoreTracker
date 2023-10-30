using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NHLTracker.Models;
using ScoreTracker.WebApi.NHLTracker.Services;

namespace ScoreTracker.WebApi.NHLTracker.Controllers;

[Route("api/{controller}/{action}")]
[ApiController]
public class NHLTrackerController : ControllerBase
{
    private readonly IScoreboardService<NHLScoreboardService> _nhlScoreboardService;

    public NHLTrackerController(IScoreboardService<NHLScoreboardService> nhlScoreboardService)
    {
        _nhlScoreboardService = nhlScoreboardService;
    }

    [HttpGet]
    public async Task<ScoreboardResponse> Scoreboard()
    {
        // return await _nhlScoreboardService.GetTodaysScoreboardAsync();
        return new();
    }

    [HttpGet]
    public async Task<ScoreboardResponse> WeeklyScoreboard()
    {
        // return await _nhlScoreboardService.GetThisWeeksScoreboardAsync();
        return new();
    }
}