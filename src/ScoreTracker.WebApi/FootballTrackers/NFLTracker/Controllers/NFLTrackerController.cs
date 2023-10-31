using Microsoft.AspNetCore.Mvc;
using ScoreTracker.WebApi.FootballTrackers.NFLTracker.Services;
using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.FootballTrackers.NFLTracker.Controllers;

[ApiController]
[Route("api/{controller}/{action}")]
public class NFLTrackerController : ControllerBase
{
    private readonly IScoreboardService<NFLScoreboardService> _scoreboardService;

    public NFLTrackerController(IScoreboardService<NFLScoreboardService> scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet]
    public async Task<IActionResult> Scoreboard()
    {
        try
        {
            var scoreboards =  await _scoreboardService.GetTodaysScoreboardAsync();

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
            var scoreboards =  await _scoreboardService.GetThisWeeksScoreboardAsync();

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