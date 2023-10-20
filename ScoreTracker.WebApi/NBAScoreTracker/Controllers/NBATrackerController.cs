using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.Models;
using ScoreTracker.WebApi.NBAScoreTracker.Models;
using ScoreTracker.WebApi.NBAScoreTracker.Services;

namespace ScoreTracker.WebApi.NBAScoreTracker.Controllers;

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
        return await _nbaScoreboardService.GetScoreboardAsync();
    }
}