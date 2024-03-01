namespace ICS.DAL.Entities;
public record PeriodicActivityDateEntity
{
    public required int IdNumber { get; set; }
    public required Guid ActivityId { get; set; }
    public required PeriodicActivityEntity PeriodicActivity { get; set; }
}
