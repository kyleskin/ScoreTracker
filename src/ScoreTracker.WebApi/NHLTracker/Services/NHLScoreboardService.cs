using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.NHLTracker.Mappers;

namespace ScoreTracker.WebApi.NHLTracker.Services;

public sealed class NHLScoreboardService : IScoreboardService<NHLScoreboardService>
{
    private readonly IFlurlClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;
    private const string BaseUri = "http://site.api.espn.com";
    private const string PathSegment = "/apis/site/v2/sports/hockey/nhl/scoreboard";

    public NHLScoreboardService(
        IFlurlClientFactory flurlClientFactory,
        IDateTimeProvider dateTimeProvider
    )
    {
        _client = flurlClientFactory.Get(BaseUri);
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ScoreboardResponse> GetTodaysScoreboardAsync()
    {
        var today = _dateTimeProvider.Today().Formatted();

        try
        {
            var res = await _client.BaseUrl
                .AppendPathSegment(PathSegment)
                .SetQueryParam("dates", today)
                .GetJsonAsync<EspnHockeyResponse>();

            return res.AsHockeyScoreboardResponse();
        }
        catch (FlurlHttpException e)
        {
            Console.WriteLine($"Error returned from {e.Call.Request.Url}: {e.Message}");
            throw;
        }
    }

    public async Task<ScoreboardResponse> GetThisWeeksScoreboardAsync()
    {
        var sunday = _dateTimeProvider.Sunday().Formatted();
        var saturday = _dateTimeProvider.Saturday().Formatted();

        try
        {
            var res = await _client.BaseUrl
                .AppendPathSegment(PathSegment)
                .SetQueryParam("dates", $"{sunday}-{saturday}")
                .GetJsonAsync<EspnHockeyResponse>();

            return res.AsHockeyScoreboardResponse();
        }
        catch (FlurlHttpException e)
        {
            Console.WriteLine($"Error returned from {e.Call.Request.Url}: {e.Message}");
            throw;
        }
    }
}
