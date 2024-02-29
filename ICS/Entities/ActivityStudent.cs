namespace ICS.DAL.Entities;
public record ActivityStudent
{
    public required Guid ActivityId { get; set; }
    public required string StudentLogin { get; set; }
}
