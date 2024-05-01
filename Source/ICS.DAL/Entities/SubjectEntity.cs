namespace ICS.DAL.Entities;

public record SubjectEntity : IEntity
{
    public required string Name { get; set; }
    public required string Abbr { get; set; }
    public required int Credits { get; set; }

    public ICollection<ActivityEntity> Activities { get; init; } = [];
    public ICollection<StudentEntity> Students { get; init; } = [];

    public required Guid Id { get; set; }
}
