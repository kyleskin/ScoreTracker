namespace ScoreTracker.WebApi.Models.EspnResponse;

public class EspnBasketballResponse
{
    public List<EspnNBAEvent> Events { get; set; } = new();
}

public class EspnNBAEvent : EspnEvent
{
    public List<EspnNBACompetition> Competitions { get; set; } = new();
}

public class EspnNBACompetition : EspnCompetition
{
    public EspnNBASituation Situation { get; set; } = new();
}

public class EspnNBASituation : EspnSituation
{
    
}