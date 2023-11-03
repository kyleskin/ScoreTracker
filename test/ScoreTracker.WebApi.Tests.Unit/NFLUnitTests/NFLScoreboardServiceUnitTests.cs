using FluentAssertions;
using Flurl.Http.Configuration;
using Flurl.Http.Testing;
using NSubstitute;
using ScoreTracker.WebApi.FootballTrackers.NFLTracker.Services;
using ScoreTracker.WebApi.Interfaces;
using ScoreTracker.WebApi.Tests.Unit.Factories.FootballFactories;

namespace ScoreTracker.WebApi.Tests.Unit.NFLUnitTests;

public class NFLScoreboardServiceUnitTests
{
    [Fact]
    public async Task NFLScoreboardServiceReturnsAScoreboard()
    {
        using (var httpTest = new HttpTest())
        {
            httpTest.RespondWithJson(EspnFootballFactory.GetEspnFootballResponse("TEN @ PIT"));
            var sut = CreateNFLScoreboardService();

            var footballScoreboard = await sut.GetTodaysScoreboardAsync();

            footballScoreboard
                .Should()
                .BeEquivalentTo(FootballScoreboardFactory.GetFootballScoreboardResponse());
        }
    }

    private static NFLScoreboardService CreateNFLScoreboardService()
    {
        return new NFLScoreboardService(CreateFlurlClientFactory(), CreateDateTimeProvider());
    }

    private static IDateTimeProvider CreateDateTimeProvider()
    {
        return Substitute.For<IDateTimeProvider>();
    }

    private static IFlurlClientFactory CreateFlurlClientFactory()
    {
        return new PerBaseUrlFlurlClientFactory();
    }
}
