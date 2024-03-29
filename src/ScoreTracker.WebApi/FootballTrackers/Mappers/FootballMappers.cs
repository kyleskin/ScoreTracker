using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.FootballTrackers.Models;
using ScoreTracker.WebApi.Mappers;

namespace ScoreTracker.WebApi.FootballTrackers.Mappers;

public static class FootballMappers
{
    public static ScoreboardResponse AsFootballScoreboardResponse(
        this EspnFootballResponse espnScoreboard
    )
    {
        ScoreboardResponse scoreboardResponse = new();

        foreach (var @event in espnScoreboard.Events)
        {
            FootballScoreboard scoreboard =
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
                    Situation = ToFootballSituation(@event.Competitions[0].Situation)
                };

            scoreboardResponse.Scoreboards.Add(scoreboard);
        }

        return scoreboardResponse;
    }

    private static FootballSituation ToFootballSituation(EspnFootballSituation espnSituation)
    {
        return new FootballSituation
        {
            Down = espnSituation.Down,
            YardLine = espnSituation.YardLine,
            Distance = espnSituation.Distance,
            DownDistanceText = espnSituation.DownDistanceText,
            ShortDownDistanceText = espnSituation.ShortDownDistanceText,
            PossessionText = espnSituation.PossessionText,
            IsRedZone = espnSituation.IsRedZone,
            HomeTimeOuts = espnSituation.HomeTimeouts,
            AwayTimeOuts = espnSituation.AwayTimeouts
        };
    }
}
