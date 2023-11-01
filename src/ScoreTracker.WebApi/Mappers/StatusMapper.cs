using ScoreTracker.WebApi.DTOs.EspnResponse;
using ScoreTracker.WebApi.Models;

namespace ScoreTracker.WebApi.Mappers;

public static class StatusMapper
{
    public static Status ToStatus(this EspnStatus espnStatus)
    {
        return new Status()
        {
            State = espnStatus.Type.State switch
            {
                "pre" => State.Scheduled,
                "in" => State.Regulation,
                "over" => State.Overtime,
                "post" => State.Post,
                _ => throw new ArgumentException("Invalid state")
            },
            DisplayClock = espnStatus.DisplayClock,
            Period = espnStatus.Period,
            Description = espnStatus.Type.Description,
            Detail = espnStatus.Type.Detail,
            ShortDetail = espnStatus.Type.ShortDetail,
            Completed = espnStatus.Type.Completed
        };
    }
}