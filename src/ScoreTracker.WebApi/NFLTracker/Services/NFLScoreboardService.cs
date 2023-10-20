using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NFLTracker.Models;

namespace ScoreTracker.WebApi.NFLTracker.Services;

public class NFLScoreboardService : IScoreboardService<NFLScoreboard>
{
    private readonly HttpClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;

    public NFLScoreboardService(HttpClient client, IDateTimeProvider dateTimeProvider)
    {
        _client = client;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<NFLScoreboard> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();
        
        var res = await _client.GetAsync($"apis/site/v2/sports/football/nfl/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NFLScoreboard>();

        return scoreboard ?? new NFLScoreboard();
    }

    public async Task<NFLScoreboard> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();
        
        var res = await _client.GetAsync($"apis/site/v2/sports/football/nfl/scoreboard?dates={sunday}-{saturday}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NFLScoreboard>();

        return scoreboard ?? new NFLScoreboard();
    }
}