using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NCAAFootball.Models;

namespace ScoreTracker.WebApi.NCAAFootball.Services;

public class NCAAFootballScoreboardService : IScoreboardService<NCAAFootballScoreboard>
{
    private readonly HttpClient _client;

    public NCAAFootballScoreboardService(HttpClient client)
    {
        _client = client;
    }

    public async Task<NCAAFootballScoreboard> GetScoreboardAsync()
    {
        var res = await _client.GetAsync("apis/site/v2/sports/football/college-football/scoreboard?dates=20231021",
            HttpCompletionOption.ResponseHeadersRead);

        res.EnsureSuccessStatusCode();
        
        var scoreboard = await res.Content.ReadFromJsonAsync<NCAAFootballScoreboard>();

        return scoreboard ?? new NCAAFootballScoreboard();
    }
}