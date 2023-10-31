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
    public async Task<IActionResult> Scoreboard()
    {
        try
        {
            var scoreboards = await _nhlScoreboardService.GetTodaysScoreboardAsync();

            if (scoreboards.Scoreboards.Count == 0)
            {
                return NoContent();
            }

            return Ok(scoreboards);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    public async Task<IActionResult> WeeklyScoreboard()
    {
        try
        {
            var scoreboards = await _nhlScoreboardService.GetThisWeeksScoreboardAsync();

            if (scoreboards.Scoreboards.Count == 0)
            {
                return NoContent();
            }

            return Ok(scoreboards);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}