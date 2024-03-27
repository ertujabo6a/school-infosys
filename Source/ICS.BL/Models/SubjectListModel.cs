namespace ICS.BL.Models;

public record SubjectListModel : ModelBase
{
    public required string SubjectName { get; set; }
    public required string SubjectAbbr { get; set; }
    public required int Credits { get; set; }

    public static SubjectListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        SubjectName = string.Empty,
        SubjectAbbr = string.Empty,
        Credits = default
    };
}
