using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NHLScoreTracker.Models;

namespace ScoreTracker.WebApi.NHLScoreTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NHLTrackerController : ControllerBase
{
    private readonly IScoreboardService<NHLScoreboard> _nhlScoreboardService;

    public NHLTrackerController(IScoreboardService<NHLScoreboard> nhlScoreboardService)
    {
        _nhlScoreboardService = nhlScoreboardService;
    }

    [HttpGet]
    public async Task<NHLScoreboard> Index()
    {
        return await _nhlScoreboardService.GetScoreboardAsync();
    }
}