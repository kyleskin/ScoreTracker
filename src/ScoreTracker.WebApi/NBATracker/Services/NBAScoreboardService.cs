using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NBATracker.Models;

namespace ScoreTracker.WebApi.NBATracker.Services;

public sealed class NBAScoreboardService : IScoreboardService<NBAScoreboard>
{
    private readonly HttpClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;

    public NBAScoreboardService(HttpClient client, IDateTimeProvider dateTimeProvider)
    {
        _client = client;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<NBAScoreboard> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();
        
        var res = await _client.GetAsync($"/apis/site/v2/sports/basketball/nba/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NBAScoreboard>();
        
        return scoreboard ?? new NBAScoreboard();
    }

    public async Task<NBAScoreboard> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();

        var res = await _client.GetAsync($"/apis/site/v2/sports/basketball/nba/scoreboard?dates={sunday}-{saturday}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NBAScoreboard>();

        return scoreboard ?? new NBAScoreboard();
    }
}