using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NHLScoreTracker.Models;

namespace ScoreTracker.WebApi.NHLScoreTracker.Services;

public sealed class NHLScoreboardService : IScoreboardService<NHLScoreboard>
{
    private readonly HttpClient _client;

    public NHLScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NHLScoreboard> GetScoreboardAsync()
    {
        var res = await _client.GetAsync("/apis/site/v2/sports/hockey/nhl/scoreboard",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NHLScoreboard>();

        return scoreboard ?? new NHLScoreboard();
    }
}