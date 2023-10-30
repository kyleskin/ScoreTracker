namespace ScoreTracker.WebApi.Models;

public class Team
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string MainColor { get; set; } = string.Empty;
    public string SecondaryColor { get; set; } = string.Empty;
    public string Score { get; set; } = string.Empty;
}