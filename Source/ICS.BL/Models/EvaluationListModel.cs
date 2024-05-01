using ICS.Common.Enums;

namespace ICS.BL.Models;

public record EvaluationListModel : ModelBase
{
    public required Guid ActivityId { get; set; }
    public required ActivityType Activity { get; set; }
    public required Guid StudentId { get; set; }
    public required string StudentName { get; set; }
    public required string StudentSurname { get; set; }
    public required int Points { get; set; }

    public static EvaluationListModel Empty => new()
    {
        Id = Guid.Empty,
        ActivityId = Guid.Empty,
        Activity = default,
        StudentId = Guid.Empty,
        StudentName = string.Empty,
        StudentSurname = string.Empty,
        Points = default
    };
}
