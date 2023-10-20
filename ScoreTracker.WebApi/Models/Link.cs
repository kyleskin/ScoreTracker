namespace ScoreTracker.WebApi.Models;

public sealed class Link
{
    public string Language { get; set; } = string.Empty;
    public List<string> Rel { get; set; } = new();
    public string Href { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string ShortText { get; set; } = string.Empty;
    public bool IsExternal { get; set; }
    public bool IsPremium { get; set; }
}