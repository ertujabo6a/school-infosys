using ICS.DAL.Entities;
using ICS.Common.Enums;

namespace ICS.BL.Models;

public record ActivityDetailModel : ModelBase
{
    public required ActivityType Type { get; set; }
    public Guid? SubjectId { get; set; }
    public SubjectListModel? Subject { get; set; }
    public required Room ActivityRoom { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public string? Description { get; set; }

    public static ActivityDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Type = default,
        ActivityRoom = default,
        StartDate = default,
        EndDate = default
    };
}
