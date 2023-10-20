using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Models;
using ScoreTracker.WebApi.MLBTracker.Services;
using ScoreTracker.WebApi.NBAScoreTracker.Models;
using ScoreTracker.WebApi.NBAScoreTracker.Services;
using ScoreTracker.WebApi.NCAAFootball.Models;
using ScoreTracker.WebApi.NCAAFootball.Services;
using ScoreTracker.WebApi.NFL.Models;
using ScoreTracker.WebApi.NFL.Services;
using ScoreTracker.WebApi.NHLScoreTracker.Models;
using ScoreTracker.WebApi.NHLScoreTracker.Services;

namespace ScoreTracker.WebApi.Helpers;

public static class Services_Extensions
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        const string espnBaseSite = "http://site.api.espn.com";
        
        
        services.AddHttpClient<IScoreboardService<MLBScoreboard>, MLBScoreboardService>((client) =>
        {
            client.BaseAddress = new Uri("http://site.api.espn.com");
        });

        services.AddHttpClient<IScoreboardService<NBAScoreboard>, NBAScoreboardService>((client) =>
        {
            client.BaseAddress = new Uri(espnBaseSite);
        });
        
        services.AddHttpClient<IScoreboardService<NCAAFootballScoreboard>, NCAAFootballScoreboardService>((client) =>
        {
            client.BaseAddress = new Uri(espnBaseSite);
        });

        services.AddHttpClient<IScoreboardService<NFLScoreboard>, NFLScoreboardService>((client) =>
        {
            client.BaseAddress = new Uri(espnBaseSite);
        });
        
        services.AddHttpClient<IScoreboardService<NHLScoreboard>, NHLScoreboardService>((client) =>
        {
            client.BaseAddress = new Uri(espnBaseSite);
        });
    }

    public static void AddScoreboardServices(this IServiceCollection services)
    {
        services.AddScoped<IScoreboardService<MLBScoreboard>, MLBScoreboardService>();
        services.AddScoped<IScoreboardService<NBAScoreboard>, NBAScoreboardService>();
        services.AddScoped<IScoreboardService<NCAAFootballScoreboard>, NCAAFootballScoreboardService>();
        services.AddScoped<IScoreboardService<NFLScoreboard>, NFLScoreboardService>();
        services.AddScoped<IScoreboardService<NHLScoreboard>, NHLScoreboardService>();
    }
}