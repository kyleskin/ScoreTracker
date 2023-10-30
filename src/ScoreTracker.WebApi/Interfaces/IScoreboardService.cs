using ScoreTracker.WebApi.DTOs;

namespace ScoreTracker.WebApi.Interfaces;

public interface IScoreboardService<T>
{
    Task<ScoreboardResponse> GetTodaysScoreboardAsync();
    Task<ScoreboardResponse> GetThisWeeksScoreboardAsync();
}