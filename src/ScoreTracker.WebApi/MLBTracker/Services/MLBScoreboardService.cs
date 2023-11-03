using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.Helpers;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.MLBTracker.Mappers;

namespace ScoreTracker.WebApi.MLBTracker.Services;

public class MLBScoreboardService : IScoreboardService<MLBScoreboardService>
{
    private readonly IFlurlClient _client;
    private readonly IDateTimeProvider _dateTimeProvider;
    private const string BaseUri = "http://site.api.espn.com";
    private const string PathSegment = "apis/site/v2/sports/baseball/mlb/scoreboard";

    public MLBScoreboardService(
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
                .GetJsonAsync<EspnBaseballReponse>();

            return res.AsBaseballScoreboardResponse();
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
                .GetJsonAsync<EspnBaseballReponse>();

            return res.AsBaseballScoreboardResponse();
        }
        catch (FlurlHttpException e)
        {
            Console.WriteLine($"Error returned from {e.Call.Request.Url}: {e.Message}");
            throw;
        }
    }
}
