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

    public async Task<MLBScoreboard> GetTodaysScoreboardAsync()
    {
        var today = DateTime.Now.ToString("yyyyMMdd");
        
        var res = await _client.GetAsync($"apis/site/v2/sports/baseball/mlb/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<MLBScoreboard>();
        
        return scoreboard ?? new MLBScoreboard();
    }
}