namespace ScoreTracker.WebApi.Interfaces;

public interface IScoreboardService<T>
{
    Task<T> GetTodaysScoreboardAsync();
    Task<T> GetThisWeeksScoreboardAsync();
}