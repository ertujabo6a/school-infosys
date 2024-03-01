namespace ICS.DAL.Entities;
public record OneOffActivityEntity
{
    public required DateOnly ActivityDate { get; set; }

    public required Guid ActivityId { get; set; }
    public required ActivityEntity Activity { get; init; }
}
