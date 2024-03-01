namespace ICS.DAL.Entities;

public record Student
{
    public required int Year { get; set; }

    public required User User { get; init; }
    public required string UserLogin { get; set; } = string.Empty;

    public ICollection<ActivityEntity> Activities { get; set; } = new List<ActivityEntity>();
}
