using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.BasketballTrackers.NBATracker.Services;
using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.BasketballTrackers.NBATracker.Controllers;

[Route("api/{controller}/{action}")]
[ApiController]
public class NBATrackerController : ControllerBase
{
    private readonly IScoreboardService<NBAScoreboardService> _scoreboardService;

    public NBATrackerController(IScoreboardService<NBAScoreboardService> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<IActionResult> Scoreboard()
    {
        try
        {
            var scoreboards = await _scoreboardService.GetTodaysScoreboardAsync();

            if (scoreboards.Scoreboards.Count == 0)
            {
                return NoContent();
            }

            return Ok(scoreboards);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> WeeklyScoreboard()
    {
        try
        {
            var scoreboards = await _scoreboardService.GetThisWeeksScoreboardAsync();

            if (scoreboards.Scoreboards.Count == 0)
            {
                return NoContent();
            }

            return Ok(scoreboards);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}
