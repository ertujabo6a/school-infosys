using ICS.Common.Enums;

namespace ICS.BL.Models;

public record EvaluationDetailModel : ModelBase
{
    public required Guid ActivityId { get; set; }
    public required ActivityType Activity { get; set; }
    public required Guid StudentId { get; set; }
    public required string StudentName { get; set; }
    public required string StudentSurname { get; set; }
    public required Guid SubjectId { get; set; }
    public required string SubjectAbbr { get; set; }
    public string? Description { get; set; }
    public required int Points { get; set; }

    public static EvaluationDetailModel Empty => new()
    {
        Id = Guid.Empty,
        ActivityId = Guid.Empty,
        Activity = default,
        StudentId = Guid.Empty,
        StudentName = string.Empty,
        StudentSurname = string.Empty,
        SubjectId = Guid.Empty,
        SubjectAbbr = string.Empty,
        Points = default
    };
}
