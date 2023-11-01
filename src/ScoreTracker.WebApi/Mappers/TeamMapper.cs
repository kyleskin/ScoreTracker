using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.Mappers;

public static class TeamMapper
{
    public static Team ToTeam(this EspnCompetitor espnCompetitor)
    {
        return new Team
        {
            Name = espnCompetitor.Team.Name,
            DisplayName = espnCompetitor.Team.DisplayName,
            ShortName = espnCompetitor.Team.ShortDisplayName,
            Abbreviation = espnCompetitor.Team.Abbreviation,
            MainColor = espnCompetitor.Team.Color,
            SecondaryColor = espnCompetitor.Team.AlternateColor,
            Score = espnCompetitor.Score
        };
    }
}