using ICS.DAL.Entities;

namespace ICS.BL.Models;

public record ActivityReferenceModel : ModelBase
{
    public required ActivityType Type;

    public static ActivityReferenceModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Type = default
    };
}
