using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Mappers;

namespace ScoreTracker.WebApi.MLBTracker.Services;

public class MLBScoreboardService : IScoreboardService<MLBScoreboardService>
{
    private readonly HttpClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;
    private const string Uri = "apis/site/v2/sports/baseball/mlb/scoreboard";

    public MLBScoreboardService(HttpClient client, IDateTimeProvider dateTimeProvider)
    {
        _client = client;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ScoreboardResponse> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();
        
        var res = await _client.GetAsync($"{Uri}?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        return await res.Content.AsBaseballScoreboardResponse();
    }

    public async Task<ScoreboardResponse> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();

        var res = await _client.GetAsync($"{Uri}?dates={sunday}-{saturday}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        return await res.Content.AsBaseballScoreboardResponse();
    }
}