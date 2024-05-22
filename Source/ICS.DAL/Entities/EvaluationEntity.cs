namespace ICS.DAL.Entities;

public record EvaluationEntity : IEntity
{
    public string? Description { get; set; }
    public required int Points { get; set; }

    public required Guid ActivityId { get; set; }
    public required Guid StudentId { get; set; }

    public ActivityEntity? Activity { get; set; }
    public StudentEntity? Student { get; set; }

    public required Guid Id { get; set; }
}
