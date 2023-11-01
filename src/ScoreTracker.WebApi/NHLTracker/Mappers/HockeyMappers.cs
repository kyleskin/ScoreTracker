using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.Mappers;
using ScoreTracker.WebApi.Models;
using ScoreTracker.WebApi.NHLTracker.Models;

namespace ScoreTracker.WebApi.NHLTracker.Mappers;

public static class HockeyMappers
{
    public static async Task<ScoreboardResponse> AsHockeyScoreboardResponse(this HttpContent content)
    {
        ScoreboardResponse scoreboardResponse = new();

        var espnScoreboard = await content.ReadFromJsonAsync<EspnHockeyResponse>();

        if (espnScoreboard is null || espnScoreboard.Events.Count == 0)
        {
            return new ScoreboardResponse();
        }

        foreach (var @event in espnScoreboard.Events)
        {
            HockeyScoreboard scoreboard = new()
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
                Situation = ToHockeySituation(@event.Competitions[0].Situtation)
            };
            
            scoreboardResponse.Scoreboards.Add(scoreboard);
        }

        return scoreboardResponse;
    }

    private static HockeySituation ToHockeySituation(EspnHockeySituation espnSituation)
    {
        return new HockeySituation();
    }
}