namespace ICS.DAL.Entities;
public record EvaluationEntity
{
    public required Guid ActivityId { get; set; }
    public required Guid StudentId { get; set; }
    public string? Description { get; set; }
    public required int Points { get; set; }
}
