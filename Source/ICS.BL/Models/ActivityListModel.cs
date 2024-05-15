using ICS.DAL.Entities;
using ICS.Common.Enums;
using System.Collections.ObjectModel;
namespace ICS.BL.Models;


public record ActivityListModel : ModelBase
{
    public new required Guid Id { get; set; }
    public required string SubjectAbbr { get; set; }
    public required ActivityType Type { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }



    public static ActivityListModel Empty => new()
    {
        Id = Guid.Empty,
        SubjectAbbr = string.Empty,
        Type = default,
        StartTime = default,
        EndTime = default
    };
}
