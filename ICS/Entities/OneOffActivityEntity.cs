namespace ICS.DAL.Entities;
public record OneOffActivityEntity
{
    public required Guid ActivityId { get; set; }
    public required DateOnly ActivityDate { get; set; }
}
