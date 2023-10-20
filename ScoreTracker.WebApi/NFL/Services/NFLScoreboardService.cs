using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NFL.Models;

namespace ScoreTracker.WebApi.NFL.Services;

public class NFLScoreboardService : IScoreboardService<NFLScoreboard>
{
    private readonly HttpClient _client;

    public NFLScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NFLScoreboard> GetScoreboardAsync()
    {
        var res = await _client.GetAsync("apis/site/v2/sports/football/nfl/scoreboard",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NFLScoreboard>();

        return scoreboard ?? new NFLScoreboard();
    }
}