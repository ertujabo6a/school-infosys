using System.Collections.ObjectModel;

namespace ICS.BL.Models;

public record EvaluationListModel : ModelBase
{
    public Guid? StudentId { get; set; }
    public StudentListModel? Student { get; set; }
    public Guid? ActivityId { get; set; }
    public ActivityListModel? Activity { get; set; }
    public required int Points { get; set; }

    public static EvaluationListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Points = default
    };
}
