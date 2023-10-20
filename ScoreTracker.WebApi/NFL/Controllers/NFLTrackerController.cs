using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NFL.Models;

namespace ScoreTracker.WebApi.NFL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NFLTrackerController : ControllerBase
{
    private readonly IScoreboardService<NFLScoreboard> _scoreboardService;

    public NFLTrackerController(IScoreboardService<NFLScoreboard> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<NFLScoreboard> Index()
    {
        return await _scoreboardService.GetScoreboardAsync();
    }
}