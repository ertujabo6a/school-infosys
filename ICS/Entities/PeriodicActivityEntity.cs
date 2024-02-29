namespace ICS.DAL.Entities;
public record PeriodicActivityEntity : IActivity
{
    public required DayOfWeek Day { get; set; }

    public Guid EntityId { get; set; }
    public string SubjectAbbr { get; set; } = string.Empty;
    public string ActivityName { get; set; } = string.Empty;
    public string TeacherLogin { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int Registered { get; set; }
    public string RoomName { get; set; } = string.Empty;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Description { get; set; } = string.Empty;
}
