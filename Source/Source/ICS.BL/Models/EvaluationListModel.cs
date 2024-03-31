namespace ICS.BL.Models;

public record EvaluationListModel : ModelBase
{
    public SubjectReferenceModel? Subject { get; set; }
    public ActivityReferenceModel? Activity { get; set; }
    public StudentReferenceModel? Student { get; set; }
    public string? Description { get; set; }
    public required int Points { get; set; }

    public static EvaluationListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Points = default
    };
}
