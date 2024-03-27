namespace ICS.BL.Models;

public record StudentReferenceModel : ModelBase
{
    public required string Name { get; set; }
    public required string Surname { get; set; }

    public static StudentReferenceModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Surname = string.Empty
    };
}
