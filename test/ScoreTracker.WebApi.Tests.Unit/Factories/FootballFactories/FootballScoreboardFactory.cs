using Flurl.Http.Configuration;
using ScoreTracker.WebApi.DTOs;
using ScoreTracker.WebApi.FootballTrackers.Models;
using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.Tests.Unit.Factories.FootballFactories;

public static class FootballScoreboardFactory
{
    public static ScoreboardResponse GetFootballScoreboardResponse()
    {
        return new ScoreboardResponse
        {
            Scoreboards = new()
            {
                new FootballScoreboard()
                {
                    DateTime = DateTime.Today,
                    Name = "Tennessee Titans at Pittsburgh Steelers",
                    ShortName = "TEN @ PIT",
                    Status = new Status
                    {
                        State = State.Scheduled,
                        DisplayClock = "15:00",
                        Period = 1,
                        Description = "Scheduled",
                        Detail = "Thu, November 2nd at 8:15 PM EDT",
                        ShortDetail = "11/2 - 8:15 PM EDT",
                        Completed = false
                    },
                    HomeTeam = new Team
                    {
                        Name = "Steelers",
                        DisplayName = "Pittsburgh Steelers",
                        ShortName = "Steelers",
                        Abbreviation = "PIT",
                        MainColor = "000000",
                        SecondaryColor = "ffb612",
                        Score = "0"
                    },
                    AwayTeam = new Team
                    {
                        Name = "Titans",
                        DisplayName = "Tennessee Titans",
                        ShortName = "Titans",
                        Abbreviation = "TEN",
                        MainColor = "4b92db",
                        SecondaryColor = "002a5c",
                        Score = "0"
                    },
                    Situation = new FootballSituation
                    {
                        Down = default,
                        YardLine = default,
                        Distance = default,
                        DownDistanceText = string.Empty,
                        ShortDownDistanceText = string.Empty,
                        PossessionText = string.Empty,
                        IsRedZone = default,
                        HomeTimeOuts = default,
                        AwayTimeOuts = default
                    }
                }
            }
        };
    }
}
