namespace ScoreTracker.WebApi.Models;

public sealed class Competition
{
    public string Id { get; set; } = string.Empty;
    public string UId { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public int Attendance { get; set; }
    public CompetitionType Type { get; set; } = new ();
    public bool TimeValid { get; set; }
    public bool NeutralSite { get; set; }
    public bool ConferenceCompetition { get; set; }
    public bool PlayByPlayAvailable { get; set; }
    public bool Recent { get; set; }
    public Venue Venue { get; set; } = new();
    public List<Competitor> Competitors { get; set; } = new();
    public List<string> Notes { get; set; } = new();
    public Status Status { get; set; } = new();
    public List<Broadcast> Broadcasts { get; set; } = new();
    public List<CompetitorLeader> Leaders { get; set; } = new();
    public Group Groups { get; set; } = new();
    public Format Format { get; set; } = new();
    public List<Ticket> Tickets { get; set; } = new();
    public string StartDate { get; set; } = string.Empty;
    public List<GeoBroadcast> GeoBroadcasts { get; set; } = new();
    public List<Odds> Odds { get; set; } = new();

}