using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.Mappers;
using ScoreTracker.WebApi.Models.EspnResponse;
using ScoreTracker.WebApi.NBATracker.Models;

namespace ScoreTracker.WebApi.NBATracker.Mappers;

public static class BasketballMappers
{
    public static async Task<ScoreboardResponse> AsBasketballScoreboardResponse(this HttpContent content)
    {
        ScoreboardResponse scoreboardResponse = new();

        var espnScoreboard = await content.ReadFromJsonAsync<EspnBasketballResponse>();

        if (espnScoreboard is null || espnScoreboard.Events.Count == 0)
        {
            return new ScoreboardResponse();
        }

        foreach (var @event in espnScoreboard.Events)
        {
            NBAScoreboard scoreboard = new()
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
                Situation = ToNBASituation(@event.Competitions[0].Situation)
            };
            
            scoreboardResponse.Scoreboards.Add(scoreboard);
        }

        return scoreboardResponse;
    }

    private static NBASituation ToNBASituation(EspnNBASituation espnSituation)
    {
        return new NBASituation();
    }
}