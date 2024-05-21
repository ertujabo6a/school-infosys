namespace ICS.BL.Models;

public record StudentToSubjectModel : ModelBase
{
    public required Guid StudentId { get; set; }
    public required Guid SubjectId { get; set; }
    public StudentListModel? Student { get; set; }
    public SubjectListModel? Subject { get; set; }

    public static StudentToSubjectModel Empty => new()
    {
        Id = Guid.Empty,
        StudentId = Guid.Empty,
        SubjectId = Guid.Empty
    };
}
