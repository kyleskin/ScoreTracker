using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.Models;
using ScoreTracker.WebApi.NCAAFootball.Models;
using ScoreTracker.WebApi.NCAAFootball.Services;

namespace ScoreTracker.WebApi.NCAAFootball.Controllers;

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
        return await _scoreboardService.GetScoreboardAsync();
    }
}