using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Models;

namespace ScoreTracker.WebApi.MLBTracker.Services;

public class MLBScoreboardService : IScoreboardService<MLBScoreboard>
{
    private readonly HttpClient _client;

    public MLBScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<MLBScoreboard> GetScoreboardAsync()
    {
        var today = DateTime.Now.ToString("yyyy-MM-dd");
        
        var res = await _client.GetAsync($"apis/site/v2/sports/baseball/mlb/scoreboard?{today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<MLBScoreboard>();
        
        return scoreboard ?? new MLBScoreboard();
    }
}