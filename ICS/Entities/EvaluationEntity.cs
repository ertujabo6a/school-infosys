namespace ICS.DAL.Entities;
public record EvaluationEntity
{
    public string? Description { get; set; }
    public required int Points { get; set; }


    public required Guid ActivityId { get; set; }
    public required Guid StudentId { get; set; }
    public required ActivityEntity Activity { get; set; }
    public required Student Student { get; set; }
}
