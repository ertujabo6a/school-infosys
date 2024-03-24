namespace ICS.DAL.Entities;

public record ActivityEntity : IEntity
{
    public required ActivityType Type { get; set; }
    public required Room Room { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public string? Description { get; set; }

    public required SubjectEntity Subject { get; set; }
    public required Guid SubjectId { get; set; }
    public ICollection<EvaluationEntity> Evaluations { get; set; } = new List<EvaluationEntity>();

    public required Guid Id { get; set; }
}
