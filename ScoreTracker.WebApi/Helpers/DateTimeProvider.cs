using ScoreTracker.WebApi.Interfaces;

namespace ScoreTracker.WebApi.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Today()
    {
        return DateTime.Today;
    }

    public DateTime Sunday()
    {
        var currentDayOfWeek = DateTime.Today.DayOfWeek;
        return DateTime.Today.AddDays(-(int)currentDayOfWeek);
    }

    public DateTime Saturday()
    {
        var currentDayOfWeek = DateTime.Today.DayOfWeek;
        return DateTime.Today.AddDays(6 - (int)currentDayOfWeek);
    }
}