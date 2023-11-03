using Flurl.Http.Configuration;
using ScoreTracker.WebApi.BasketballTrackers.NBATracker.Services;
using ScoreTracker.WebApi.FootballTrackers.NCAAFootballTracker.Services;
using ScoreTracker.WebApi.FootballTrackers.NFLTracker.Services;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Services;
using ScoreTracker.WebApi.NHLTracker.Services;

namespace ScoreTracker.WebApi.Helpers;

public static class ServicesExtensions
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        const string espnBaseSite = "http://site.api.espn.com";

        services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

        services.AddHttpClient<
            IScoreboardService<NHLScoreboardService>,
            NHLScoreboardService
        >(client =>
        {
            client.BaseAddress = new Uri(espnBaseSite);
        });
    }

    public static void AddScoreboardServices(this IServiceCollection services)
    {
        services.AddScoped<IScoreboardService<MLBScoreboardService>, MLBScoreboardService>();
        services.AddScoped<IScoreboardService<NBAScoreboardService>, NBAScoreboardService>();
        services.AddScoped<
            IScoreboardService<NCAAFootballScoreboardService>,
            NCAAFootballScoreboardService
        >();
        services.AddScoped<IScoreboardService<NFLScoreboardService>, NFLScoreboardService>();
        services.AddScoped<IScoreboardService<NHLScoreboardService>, NHLScoreboardService>();
    }
}
