using ICS.DAL.Entities;
using ICS.Common.Enums;
using System.Collections.ObjectModel;
namespace ICS.BL.Models;


public record ActivityListModel : ModelBase
{
    public required ActivityType Type { get; set; }

    public static ActivityListModel Empty => new()
    {
        Id = Guid.Empty,
        Type = default
    };
}
