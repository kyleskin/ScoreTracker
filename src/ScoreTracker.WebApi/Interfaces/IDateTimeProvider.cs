namespace ScoreTracker.WebApi.Interfaces;

public interface IDateTimeProvider
{
    DateTime Today();
    DateTime Sunday();
    DateTime Saturday();
}