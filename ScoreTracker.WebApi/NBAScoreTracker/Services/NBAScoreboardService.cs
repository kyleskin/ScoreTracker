using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NBAScoreTracker.Models;

namespace ScoreTracker.WebApi.NBAScoreTracker.Services;

public sealed class NBAScoreboardService : IScoreboardService<NBAScoreboard>
{
    private readonly HttpClient _client;

    public NBAScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NBAScoreboard> GetScoreboardAsync()
    {
        var res = await _client.GetAsync("/apis/site/v2/sports/basketball/nba/scoreboard",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NBAScoreboard>();
        
        return scoreboard ?? new NBAScoreboard();
    }
}