using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NCAAFootballTracker.Models;

namespace ScoreTracker.WebApi.NCAAFootballTracker.Services;

public class NCAAFootballScoreboardService : IScoreboardService<NCAAFootballScoreboard>
{
    private readonly HttpClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;

    public NCAAFootballScoreboardService(HttpClient client, IDateTimeProvider dateTimeProvider)
    {
        _client = client;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<NCAAFootballScoreboard> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();
        
        var res = await _client.GetAsync($"apis/site/v2/sports/football/college-football/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();
        
        var scoreboard = await res.Content.ReadFromJsonAsync<NCAAFootballScoreboard>();

        return scoreboard ?? new NCAAFootballScoreboard();
    }

    public async Task<NCAAFootballScoreboard> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();
        
        var res = await _client.GetAsync($"apis/site/v2/sports/football/college-football/scoreboard?dates={sunday}-{saturday}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NCAAFootballScoreboard>();

        return scoreboard ?? new NCAAFootballScoreboard();
    }
}