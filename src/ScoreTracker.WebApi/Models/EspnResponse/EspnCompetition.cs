namespace ScoreTracker.WebApi.Models.EspnResponse;

public class EspnCompetition
{
    public string Date { get; set; } = string.Empty;
    public EspnStatus Status { get; set; } = new();
    public List<Competitor> Competitors { get; set; } = new();
}