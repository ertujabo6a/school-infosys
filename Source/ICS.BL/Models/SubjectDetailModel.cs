using System.Collections.ObjectModel;

namespace ICS.BL.Models;

public record SubjectDetailModel : ModelBase
{
    public required string SubjectName { get; set; }
    public required string SubjectAbbr { get; set; }
    public required int Credits { get; set; }
    public ObservableCollection<StudentListModel> Students { get; set; } = new();
    public ObservableCollection<ActivityListModel> Activities { get; set; } = new();

    public static SubjectDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        SubjectName = string.Empty,
        SubjectAbbr = string.Empty,
        Credits = default
    };
}
