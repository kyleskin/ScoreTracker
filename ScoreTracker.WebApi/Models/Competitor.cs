using Microsoft.AspNetCore.Mvc;

namespace ScoreTracker.WebApi.Models;

public sealed class Competitor
{
    public string Id { get; set; } = string.Empty;
    public string UId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Order { get; set; }
    public string HomeAway { get; set; } = string.Empty;
    public Team Team { get; set; } = new();
    public string Score { get; set; } = string.Empty;
    public CuratedRank CuratedRank { get; set; } = new();
    public List<Statistic> Statistics { get; set; } = new();
    public List<TeamRecord> Records { get; set; } = new();
    public List<CompetitorLeader> Leaders { get; set; } = new();
}