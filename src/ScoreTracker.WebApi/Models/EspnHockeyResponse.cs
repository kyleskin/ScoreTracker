using ScoreTracker.WebApi.Models.EspnResponse;

namespace ScoreTracker.WebApi.Models;

public class EspnHockeyResponse
{
    public List<EspnHockeyEvent> Events { get; set; } = new();
}

public class EspnHockeyEvent : EspnEvent
{
    public List<EspnHockeyCompetition> Competitions { get; set; } = new();
}

public class EspnHockeyCompetition : EspnCompetition
{
    public EspnHockeySituation Situtation { get; set; } = new();
}

public class EspnHockeySituation : EspnSituation
{
    
}