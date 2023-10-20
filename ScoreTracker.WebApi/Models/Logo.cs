namespace ScoreTracker.WebApi.Models;

public sealed class Logo
{
    public string Href { get; set; } = string.Empty;
    public int Width { get; set; }
    public int Height { get; set; }
    public string Alt { get; set; } = string.Empty;
    public List<string> Rel { get; set; } = new();
}