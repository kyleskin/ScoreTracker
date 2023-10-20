namespace ScoreTracker.WebApi.Models;

public sealed class CompetitorLeader
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ShortDisplayName { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public List<Leader> Leaders { get; set; } = new();
}