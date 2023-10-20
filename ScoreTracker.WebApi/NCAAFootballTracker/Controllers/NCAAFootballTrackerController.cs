using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NCAAFootballTracker.Models;

namespace ScoreTracker.WebApi.NCAAFootballTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class NCAAFootballTrackerController : ControllerBase
{
    private readonly IScoreboardService<NCAAFootballScoreboard> _scoreboardService;

    public NCAAFootballTrackerController(IScoreboardService<NCAAFootballScoreboard> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<NCAAFootballScoreboard> Index()
    {
        return await _scoreboardService.GetTodaysScoreboardAsync();
    }
}