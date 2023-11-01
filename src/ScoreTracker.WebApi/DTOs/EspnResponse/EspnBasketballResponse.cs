namespace ScoreTracker.WebApi.DTOs.EspnResponse;

public class EspnBasketballResponse
{
    public List<EspnBasketballEvent> Events { get; set; } = new();
}

public class EspnBasketballEvent : EspnEvent
{
    public List<EspnBasketballCompetition> Competitions { get; set; } = new();
}

public class EspnBasketballCompetition : EspnCompetition
{
    public EspnNBASituation Situation { get; set; } = new();
}

public class EspnNBASituation : EspnSituation
{
    
}