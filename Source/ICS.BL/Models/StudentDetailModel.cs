using System.Collections.ObjectModel;

namespace ICS.BL.Models;

public record StudentDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? ImageUrl { get; set; }
    public ObservableCollection<SubjectListModel> Subjects { get; set; } = new();

    public static StudentDetailModel Empty => new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Surname = string.Empty
    };
}
