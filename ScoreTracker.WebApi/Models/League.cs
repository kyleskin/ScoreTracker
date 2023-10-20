namespace ScoreTracker.WebApi.Models;

public sealed class League
{
    public string Id { get; set; } = string.Empty;
    public string UId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public LeagueSeason Season { get; set; } = new();
    public List<Logo> Logos { get; set; } = new();
    public string CalendarType { get; set; } = string.Empty;
    public bool CalendarIsWhiteList { get; set; }
    public string CalendarStartDate { get; set; } = string.Empty;
    public string CalendarEndDate { get; set; } = string.Empty;
    // public List<Calendar> Calendar { get; set; } = new();
}