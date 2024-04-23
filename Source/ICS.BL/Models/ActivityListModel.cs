using ICS.DAL.Entities;
using ICS.Common.Enums;
using System.Collections.ObjectModel;
namespace ICS.BL.Models;


public record ActivityListModel : ModelBase
{
    public Guid? SubjectId { get; set; }
    public SubjectListModel? Subject { get; set; }
    public required ActivityType Type { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }



    public static ActivityListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Type = default,
        StartDate = default,
        EndDate = default
    };
}
