namespace ICS.BL.Models;

public record SubjectReferenceModel : ModelBase
{
    public required string SubjectAbbr { get; set; }

    public static SubjectReferenceModel Empty => new()
    {
        Id = Guid.NewGuid(),
        SubjectAbbr = String.Empty
    };
}
