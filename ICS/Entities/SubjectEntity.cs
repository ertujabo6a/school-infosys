namespace ICS.DAL.Entities;

public record SubjectEntity : IEntity
{
    public required string Name { get; set; }
    public required string Abbr { get; set; }
    public required int Credits { get; set; }

    public ICollection<ActivityEntity> Activities { get; set; } = new List<ActivityEntity>();
    public ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();
    public required Guid Id { get; set; }

}
