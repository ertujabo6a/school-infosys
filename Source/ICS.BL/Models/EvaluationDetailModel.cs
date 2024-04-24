namespace ICS.BL.Models;

public record EvaluationDetailModel : ModelBase
{
    public Guid ActivityId { get; set; }
    public ActivityListModel? Activity { get; set; }
    public Guid StudentId { get; set; }
    public StudentListModel? Student { get; set; }
    public string? Description { get; set; }
    public required int Points { get; set; }

    public static EvaluationDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Points = default,
        ActivityId = Guid.Empty,
        StudentId = Guid.Empty
    };
}
