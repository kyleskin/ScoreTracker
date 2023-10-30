namespace ScoreTracker.WebApi.Models;

public class Status
{
    public State State { get; set; }
    public string DisplayClock { get; set; } = string.Empty;
    public int Period { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string ShortDetail { get; set; } = string.Empty;
    public bool Completed { get; set; }

}

public enum State
{
    Scheduled,
    Regulation,
    Overtime,
    Post
}