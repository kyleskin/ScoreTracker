using System.ComponentModel;

namespace ScoreTracker.WebApi.MLBTracker.Models;

public sealed class Status
{
    [DisplayName(displayName: "Inning")]
    public int Period { get; set; }

    public StatusType Type { get; set; } = new();
}