using System.Globalization;
using ScoreTracker.WebApi.DTOs.EspnResponse;

namespace ScoreTracker.WebApi.Tests.Unit.Factories.FootballFactories;

public static class EspnFootballFactory
{
    public static EspnFootballResponse GetEspnFootballResponse(string game)
    {
        return game switch
        {
            "TEN @ PIT"
                => new EspnFootballResponse
                {
                    Events = new List<EspnFootballEvent>()
                    {
                        new()
                        {
                            Date = DateTime.Today.ToString(CultureInfo.InvariantCulture),
                            Name = "Tennessee Titans at Pittsburgh Steelers",
                            ShortName = "TEN @ PIT",
                            Competitions = new List<EspnFootballCompetition>()
                            {
                                new()
                                {
                                    Status = new EspnStatus()
                                    {
                                        Clock = 900,
                                        DisplayClock = "15:00",
                                        Period = 1,
                                        Type = new EspnStatusType()
                                        {
                                            State = "pre",
                                            Completed = false,
                                            Description = "Scheduled",
                                            Detail = "Thu, November 2nd at 8:15 PM EDT",
                                            ShortDetail = "11/2 - 8:15 PM EDT"
                                        }
                                    },
                                    Situation = new EspnFootballSituation(),
                                    Competitors = new List<EspnCompetitor>()
                                    {
                                        new()
                                        {
                                            HomeAway = "home",
                                            Team = new EspnTeam()
                                            {
                                                Name = "Steelers",
                                                Abbreviation = "PIT",
                                                DisplayName = "Pittsburgh Steelers",
                                                ShortDisplayName = "Steelers",
                                                Color = "000000",
                                                AlternateColor = "ffb612"
                                            },
                                            Score = "0"
                                        },
                                        new()
                                        {
                                            HomeAway = "away",
                                            Team = new EspnTeam()
                                            {
                                                Name = "Titans",
                                                Abbreviation = "TEN",
                                                DisplayName = "Tennessee Titans",
                                                ShortDisplayName = "Titans",
                                                Color = "4b92db",
                                                AlternateColor = "002a5c"
                                            },
                                            Score = "0"
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
            "MIA @ KS"
                => new EspnFootballResponse
                {
                    Events = new List<EspnFootballEvent>()
                    {
                        new()
                        {
                            Date = DateTime.Today.ToString(CultureInfo.InvariantCulture),
                            Name = "Miami Dolphins at Kansas City Chiefs",
                            ShortName = "MIA @ KC",
                            Competitions = new List<EspnFootballCompetition>()
                            {
                                new()
                                {
                                    Status = new EspnStatus()
                                    {
                                        Clock = 0,
                                        DisplayClock = "0:00",
                                        Period = 0,
                                        Type = new EspnStatusType()
                                        {
                                            State = "pre",
                                            Completed = false,
                                            Description = "Scheduled",
                                            Detail = "Sun, November 5th at 9:20 AM EDT",
                                            ShortDetail = "11/5 - 9:30 AM EDT"
                                        }
                                    },
                                    Situation = new EspnFootballSituation(),
                                    Competitors = new List<EspnCompetitor>()
                                    {
                                        new()
                                        {
                                            HomeAway = "home",
                                            Team = new EspnTeam()
                                            {
                                                Name = "Chiefs",
                                                Abbreviation = "KC",
                                                DisplayName = "Kansas City Chiefs",
                                                ShortDisplayName = "Chiefs",
                                                Color = "e31837",
                                                AlternateColor = "ffb612"
                                            },
                                            Score = "0"
                                        },
                                        new()
                                        {
                                            HomeAway = "away",
                                            Team = new EspnTeam()
                                            {
                                                Name = "Dolphins",
                                                Abbreviation = "MIA",
                                                DisplayName = "Miami Dolphins",
                                                ShortDisplayName = "Dolphins",
                                                Color = "008e97",
                                                AlternateColor = "fc4c02"
                                            },
                                            Score = "0"
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
            _ => new EspnFootballResponse()
        };
    }
}
