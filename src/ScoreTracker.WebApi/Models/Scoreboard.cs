namespace ScoreTracker.WebApi.Models;

public abstract class Scoreboard
{
    public DateTime DateTime { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public Status Status { get; set; } = new();
    public Team HomeTeam { get; set; } = new();
    public Team AwayTeam { get; set; } = new();
}