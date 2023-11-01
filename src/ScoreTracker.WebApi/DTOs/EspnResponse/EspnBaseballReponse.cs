namespace ScoreTracker.WebApi.DTOs.EspnResponse;

public class EspnBaseballReponse
{
    public List<EspnBaseballEvent> Events { get; set; } = new();
}

public class EspnBaseballEvent : EspnEvent
{
    public List<EspnBaseballCompetition> Competitions { get; set; } = new();
}

public class EspnBaseballCompetition : EspnCompetition
{
    public EspnBaseballSituation Situation { get; set; } = new();
}

public class EspnBaseballSituation : EspnSituation
{
    
}