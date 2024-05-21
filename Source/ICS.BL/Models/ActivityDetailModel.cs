using ICS.DAL.Entities;
using ICS.Common.Enums;

namespace ICS.BL.Models;

public record ActivityDetailModel : ModelBase
{
    public new required Guid Id { get; set; }
    public required ActivityType Type { get; set; }
    public required Guid SubjectId { get; set; }
    public required string SubjectAbbr { get; set; }
    public required Room ActivityRoom { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public string? Description { get; set; }

    public static ActivityDetailModel Empty => new()
    {
        Id = Guid.Empty,
        SubjectId = Guid.Empty,
        SubjectAbbr = string.Empty,
        Type = default,
        ActivityRoom = default,
        StartTime = default,
        EndTime = default
    };
}
