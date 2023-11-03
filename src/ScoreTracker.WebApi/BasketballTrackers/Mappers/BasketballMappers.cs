using ScoreTracker.WebApi.BasketballTrackers.Models;
using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.Mappers;

namespace ScoreTracker.WebApi.BasketballTrackers.Mappers;

public static class BasketballMappers
{
    public static ScoreboardResponse AsBasketballScoreboardResponse(
        this EspnBasketballResponse espnScoreboard
    )
    {
        ScoreboardResponse scoreboardResponse = new();

        foreach (var @event in espnScoreboard.Events)
        {
            BasketballScoreboard scoreboard =
                new()
                {
                    DateTime = DateTime.Parse(@event.Date),
                    Name = @event.Name,
                    ShortName = @event.ShortName,
                    Status = @event.Competitions[0].Status.ToStatus(),
                    HomeTeam = @event.Competitions[0].Competitors
                        .Single(x => x.HomeAway == "home")
                        .ToTeam(),
                    AwayTeam = @event.Competitions[0].Competitors
                        .Single(x => x.HomeAway == "away")
                        .ToTeam(),
                    Situation = ToBasketballSituation(@event.Competitions[0].Situation)
                };

            scoreboardResponse.Scoreboards.Add(scoreboard);
        }

        return scoreboardResponse;
    }

    private static BasketballSituation ToBasketballSituation(EspnNBASituation espnSituation)
    {
        return new BasketballSituation();
    }
}
