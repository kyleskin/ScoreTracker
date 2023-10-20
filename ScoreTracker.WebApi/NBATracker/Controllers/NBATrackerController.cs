using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NBATracker.Models;

namespace ScoreTracker.WebApi.NBATracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NBATrackerController : ControllerBase
{
    private readonly IScoreboardService<NBAScoreboard> _nbaScoreboardService;

    public NBATrackerController(IScoreboardService<NBAScoreboard> nbaScoreboardService)
    {
        _nbaScoreboardService = nbaScoreboardService;
    }

    [HttpGet]
    public async Task<NBAScoreboard> Index()
    {
        return await _nbaScoreboardService.GetTodaysScoreboardAsync();
    }
}