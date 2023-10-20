using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NFLTracker.Models;

namespace ScoreTracker.WebApi.NFLTracker.Services;

public class NFLScoreboardService : IScoreboardService<NFLScoreboard>
{
    private readonly HttpClient _client;

    public NFLScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NFLScoreboard> GetTodaysScoreboardAsync()
    {
        var today = DateTime.Now.ToString("yyyyMMdd");
        
        var res = await _client.GetAsync($"apis/site/v2/sports/football/nfl/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();

        var scoreboard = await res.Content.ReadFromJsonAsync<NFLScoreboard>();

        return scoreboard ?? new NFLScoreboard();
    }
}