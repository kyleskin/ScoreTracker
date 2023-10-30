using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.FootballTrackers.Mappers;
using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.FootballTrackers.NCAAFootballTracker.Services;

public class NCAAFootballScoreboardService : IScoreboardService<NCAAFootballScoreboardService>
{
    private readonly HttpClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;

    public NCAAFootballScoreboardService(HttpClient client, IDateTimeProvider dateTimeProvider)
    {
        _client = client;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ScoreboardResponse> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();
        
        var res = await _client.GetAsync($"apis/site/v2/sports/football/college-football/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        return await res.Content.AsFootballScoreboardResponse();
    }

    public async Task<ScoreboardResponse> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();

        var res = await _client.GetAsync(
            $"apis/site/v2/sports/football/college-football/scoreboard?dates={sunday}-{saturday}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        return await res.Content.AsFootballScoreboardResponse();
    }
}