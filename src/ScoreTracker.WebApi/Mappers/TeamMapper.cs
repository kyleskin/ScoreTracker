using ScoreTracker.WebApi.Models;
using ScoreTracker.WebApi.Models.EspnResponse;

namespace ScoreTracker.WebApi.Mappers;

public static class TeamMapper
{
    public static Team ToTeam(this Competitor competitor)
    {
        return new Team
        {
            Name = competitor.Team.Name,
            DisplayName = competitor.Team.DisplayName,
            ShortName = competitor.Team.ShortDisplayName,
            Abbreviation = competitor.Team.Abbreviation,
            MainColor = competitor.Team.Color,
            SecondaryColor = competitor.Team.AlternateColor,
            Score = competitor.Score
        };
    }
}