using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Models;

namespace ScoreTracker.WebApi.MLBTracker.Services;

public class MLBScoreboardService : IScoreboardService<MLBScoreboard>
{
    private readonly HttpClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;

    public MLBScoreboardService(HttpClient client, IDateTimeProvider dateTimeProvider)
    {
        _client = client;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<MLBScoreboard> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();
        
        var res = await _client.GetAsync($"apis/site/v2/sports/baseball/mlb/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<MLBScoreboard>();
        
        return scoreboard ?? new MLBScoreboard();
    }

    public async Task<MLBScoreboard> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();

        var res = await _client.GetAsync($"apis/site/v2/sports/baseball/mlb/scoreboard?dates={sunday}-{saturday}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<MLBScoreboard>();

        return scoreboard ?? new MLBScoreboard();
    }
}