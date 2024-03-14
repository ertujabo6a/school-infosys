namespace ICS.DAL.Entities;
public record Subject : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Abbr { get; set; }
    public required int Credits { get; set; }
    public ICollection<ActivityEntity> Activities { get; set; } = new List<ActivityEntity>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
    
}
