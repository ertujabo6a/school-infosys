namespace ICS.DAL.Entities;

public record ActivityEntity
{
    public required Guid EntityId { get; set; }
    public required string SubjectAbbr { get; set; } = string.Empty;
    public required string ActivityName { get; set; } = string.Empty;
    public required string TeacherLogin { get; set; } = string.Empty;
    public required int Capacity { get; set; }
    public required int Registered { get; set; }
    public required string RoomName { get; set; } = string.Empty;
    public required TimeSpan StartTime { get; set; }
    public required TimeSpan EndTime { get; set; }
    public required string Description { get; set; } = string.Empty;
}
