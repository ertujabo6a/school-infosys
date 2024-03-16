namespace ICS.DAL.Entities;

public record ActivityEntity : IEntity
{
    public required ActivityType Type { get; set; }
    public required Room Room { get; init; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required string Description { get; set; } = string.Empty;

    public required string SubjectAbbr { get; set; } = string.Empty;
    public required SubjectEntity Subject { get; init; }
    public ICollection<EvaluationEntity> Evaluations { get; set; } = new List<EvaluationEntity>();
    public required Guid Id { get; set; }
}
