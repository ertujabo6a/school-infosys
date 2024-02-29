namespace ICS.DAL.Entities;

public interface IActivity
{
    public Guid EntityId { get; set; }
    public string SubjectAbbr { get; set; }
    public string ActivityName { get; set; }
    public string TeacherLogin { get; set; }
    public int Capacity { get; set; }
    public int Registered { get; set; }
    public string RoomName { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Description { get; set; }
}
