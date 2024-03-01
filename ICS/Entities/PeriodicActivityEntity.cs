namespace ICS.DAL.Entities;
public record PeriodicActivityEntity
{
    public required DayOfWeek Day { get; set; }

    public required Guid ActivityId { get; set; }
    public required ActivityEntity Activity { get; set; }
    public ICollection<PeriodicActivityDateEntity> ActivityDates { get; set; } = new List<PeriodicActivityDateEntity>();
}
