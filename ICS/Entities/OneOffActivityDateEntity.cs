namespace ICS.DAL.Entities;
public record DayOffActivityDateEntity
{
    public required Guid ActivityId { get; set; }
    public required int IdNumber { get; set; }
}
