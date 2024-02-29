namespace ICS.DAL.Entities;
public record PeriodicActivityEntity
{
    public required Guid ActivityId { get; set; }
    public required DayOfWeek Day { get; set; }
}
