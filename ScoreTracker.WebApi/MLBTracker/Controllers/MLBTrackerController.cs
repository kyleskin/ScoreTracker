using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Models;
using ScoreTracker.WebApi.MLBTracker.Services;
using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.MLBTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MLBTrackerController : ControllerBase
{
    private readonly IScoreboardService<MLBScoreboard> _scoreboardService;

    public MLBTrackerController(IScoreboardService<MLBScoreboard> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    public async Task<MLBScoreboard> Index()
    {
        return await _scoreboardService.GetScoreboardAsync();
    }
}