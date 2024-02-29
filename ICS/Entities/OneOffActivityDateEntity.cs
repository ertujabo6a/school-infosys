namespace ICS.DAL.Entities;
public record OneOffActivityDateEntity
{
    public required Guid ActivityId { get; set; }
    public required int IdNumber { get; set; }
}
