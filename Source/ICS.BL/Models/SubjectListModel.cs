namespace ICS.BL.Models;

public record SubjectListModel : ModelBase
{
    public required string SubjectAbbr { get; set; }

    public static SubjectListModel Empty => new()
    {
        Id = Guid.Empty,
        SubjectAbbr = string.Empty
    };
}
