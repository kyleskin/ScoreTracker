using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.FootballTrackers.NCAAFootballTracker.Services;
using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.FootballTrackers.NCAAFootballTracker.Controllers;

[ApiController]
[Route("/api/{controller}/{action}")]
public class NCAAFootballTrackerController : ControllerBase
{
    private readonly IScoreboardService<NCAAFootballScoreboardService> _scoreboardService;

    public NCAAFootballTrackerController(IScoreboardService<NCAAFootballScoreboardService> scoreboardService)
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