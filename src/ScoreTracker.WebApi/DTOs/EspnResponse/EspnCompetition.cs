namespace ScoreTracker.WebApi.DTOs.EspnResponse;

public class EspnCompetition
{
    public string Date { get; set; } = string.Empty;
    public EspnStatus Status { get; set; } = new();
    public List<EspnCompetitor> Competitors { get; set; } = new();
}