using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NHLTracker.Models;

namespace ScoreTracker.WebApi.NHLTracker.Services;

public sealed class NHLScoreboardService : IScoreboardService<NHLScoreboard>
{
    private readonly HttpClient _client;

    public NHLScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NHLScoreboard> GetTodaysScoreboardAsync()
    {
        var today = DateTime.Now.ToString("yyyyMMdd");
        
        var res = await _client.GetAsync($"/apis/site/v2/sports/hockey/nhl/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NHLScoreboard>();

        return scoreboard ?? new NHLScoreboard();
    }
}