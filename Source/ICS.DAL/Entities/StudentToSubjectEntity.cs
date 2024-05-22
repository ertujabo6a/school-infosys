namespace ICS.DAL.Entities;

public record StudentToSubjectEntity : IEntity
{
    public required Guid StudentId { get; set; }
    public StudentEntity? Student { get; set; }
    public required Guid SubjectId { get; set; }
    public SubjectEntity? Subject { get; set; }
    public required Guid Id { get; set; }
}
