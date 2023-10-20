using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NBATracker.Models;

namespace ScoreTracker.WebApi.NBATracker.Services;

public sealed class NBAScoreboardService : IScoreboardService<NBAScoreboard>
{
    private readonly HttpClient _client;

    public NBAScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NBAScoreboard> GetTodaysScoreboardAsync()
    {
        var today = DateTime.Now.ToString("yyyyMMdd");
        
        var res = await _client.GetAsync($"/apis/site/v2/sports/basketball/nba/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NBAScoreboard>();
        
        return scoreboard ?? new NBAScoreboard();
    }

    public Task<NBAScoreboard> GetThisWeeksScoreboardAsync()
    {
        throw new NotImplementedException();
    }
}