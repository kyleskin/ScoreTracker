using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NCAAFootballTracker.Models;

namespace ScoreTracker.WebApi.NCAAFootballTracker.Services;

public class NCAAFootballScoreboardService : IScoreboardService<NCAAFootballScoreboard>
{
    private readonly HttpClient _client;

    public NCAAFootballScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NCAAFootballScoreboard> GetTodaysScoreboardAsync()
    {
        var today = DateTime.Now.ToString("yyyyMMdd");
        
        var res = await _client.GetAsync($"apis/site/v2/sports/football/college-football/scoreboard?dates={today}",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();
        
        var scoreboard = await res.Content.ReadFromJsonAsync<NCAAFootballScoreboard>();

        return scoreboard ?? new NCAAFootballScoreboard();
    }
}