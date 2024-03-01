namespace ICS.DAL.Entities;

public record ActivityEntity
{
    public required Guid EntityId { get; set; }
    public required string ActivityName { get; set; } = string.Empty;
    public required string TeacherLogin { get; set; } = string.Empty;
    public required string RoomName { get; set; } = string.Empty;
    public required TimeSpan StartTime { get; set; }
    public required TimeSpan EndTime { get; set; }
    public required string Description { get; set; } = string.Empty;

    public required Subject Subject { get; init; }
    public required string SubjectAbbr { get; set; } = string.Empty;

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
