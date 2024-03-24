using System.Collections.ObjectModel;

namespace ICS.BL.Models;

public record StudentListModel : ModelBase
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? ImageUrl { get; set; }
    public ObservableCollection<SubjectReferenceModel> Subjects { get; set; } = new();

    public static StudentListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Surname = string.Empty
    };
}
