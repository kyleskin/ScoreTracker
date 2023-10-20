using ScoreTracker.WebApi.MLBTracker.Models;
using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.Interfaces;

public interface IScoreboardService<T>
{
    Task<T> GetScoreboardAsync();
}