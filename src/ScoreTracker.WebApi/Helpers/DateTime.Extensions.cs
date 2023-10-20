namespace ScoreTracker.WebApi.Helpers;

public static class DateTimeExtensions
{
    public static string Formatted(this DateTime dateTime) => dateTime.ToString("yyyyMMdd");
}