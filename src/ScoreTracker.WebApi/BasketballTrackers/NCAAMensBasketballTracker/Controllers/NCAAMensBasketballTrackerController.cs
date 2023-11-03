using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.BasketballTrackers.NCAAMensBasketballTracker.Services;
using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.BasketballTrackers.NCAAMensBasketballTracker.Controllers;

[Route("api/{controller}/{action}")]
[ApiController]
public class NCAAMensBasketballTrackerController : ControllerBase
{
    private readonly IScoreboardService<NCAAMensBasketballService> _scoreboardService;

    public NCAAMensBasketballTrackerController(
        IScoreboardService<NCAAMensBasketballService> scoreboardService
    )
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
