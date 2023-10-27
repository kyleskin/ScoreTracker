using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NHLTracker.Models;

namespace ScoreTracker.WebApi.NHLTracker.Services;

public sealed class NHLScoreboardService : IScoreboardService<NHLScoreboard>
{
    private readonly HttpClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;

    public NHLScoreboardService(HttpClient client, IDateTimeProvider dateTimeProvider)
    {
        _client = client;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<NHLScoreboard> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();
        
        var res = await _client.GetAsync($"/apis/site/v2/sports/hockey/nhl/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NHLScoreboard>();

        return scoreboard ?? new NHLScoreboard();
    }

    public async Task<NHLScoreboard> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();
        
        var res = await _client.GetAsync($"/apis/site/v2/sports/hockey/nhl/scoreboard?dates={sunday}-{saturday}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NHLScoreboard>();

        return scoreboard ?? new NHLScoreboard();
    }
}