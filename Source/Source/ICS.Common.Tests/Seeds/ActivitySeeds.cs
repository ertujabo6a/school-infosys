using ICS.Common.Enums;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity EmptyActivityEntity = new()
    {
        Id = default,
        Type = default,
        Room = default,
        StartTime = default,
        EndTime = default,
        Description = default,
        SubjectId = default,
        Subject = default!,
    };

    public static readonly ActivityEntity ActivityEntity = new()
    {
        Id = Guid.Parse(input: "fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        Type = ActivityType.Lecture,
        Room = Room.E112,
        StartTime = new DateTime(2024, 3, 28, 12, 0, 0),
        EndTime = new DateTime(2024, 3, 28, 13, 50, 0),
        Description = "ICS Testing Lecture",
        SubjectId = SubjectSeeds.SubjectForActivity.Id,
        Subject = null!
    };

    public static readonly ActivityEntity ActivityInEvaluation = new()
    {
        Id = Guid.Parse(input: "fabde0cd-eefe-443f-34f6-3d96cc2cbf2f"),
        Type = ActivityType.Seminar,
        Room = Room.A113,
        StartTime = new DateTime(2024, 3, 28, 14, 0, 0),
        EndTime = new DateTime(2024, 3, 28, 15, 50, 0),
        Description = "IMA Testing Seminar",
        SubjectId = SubjectSeeds.SubjectForActivity.Id,
        Subject = null!
    };
}
