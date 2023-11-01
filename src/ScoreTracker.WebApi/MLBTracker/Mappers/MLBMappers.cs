using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.Mappers;
using ScoreTracker.WebApi.MLBTracker.Models;

namespace ScoreTracker.WebApi.MLBTracker.Mappers;

public static class MLBMappers
{
    public static async Task<ScoreboardResponse> AsBaseballScoreboardResponse(this HttpContent content)
    {
        ScoreboardResponse scoreboardResponse = new();

        var espnScoreboard = await content.ReadFromJsonAsync<EspnBaseballReponse>();

        if (espnScoreboard is null || espnScoreboard.Events.Count == 0)
        {
            return new ScoreboardResponse();
        }

        foreach (var @event in espnScoreboard.Events)
        {
            BaseballScoreboard scoreboard = new()
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
                Situation = ToBaseballSituation(@event.Competitions[0].Situation)
            };
            
            scoreboardResponse.Scoreboards.Add(scoreboard);
        }

        return scoreboardResponse;
    }

    private static BaseballSituation ToBaseballSituation(EspnBaseballSituation espnBaseballSituation)
    {
        return new BaseballSituation();
    }
}