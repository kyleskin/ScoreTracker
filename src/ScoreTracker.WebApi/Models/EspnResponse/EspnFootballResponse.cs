namespace ScoreTracker.WebApi.Models.EspnResponse;

public class EspnFootballResponse : EspnResponse
{
    public List<EspnFootballEvent> Events { get; set; } = new();
}

public class EspnFootballEvent : EspnEvent
{
    public List<EspnFootballCompetition> Competitions { get; set; } = new();
}

public class EspnFootballCompetition : EspnCompetition
{
    public EspnFootballSituation Situation { get; set; } = new EspnFootballSituation();
} 