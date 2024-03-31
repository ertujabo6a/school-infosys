using ICS.Common.Enums;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity EmptySubjectEntity = new()
    {
        Id = default,
        Name = default!,
        Abbr = default!,
        Credits = default!,
    };

    public static readonly SubjectEntity SubjectForActivity = new()
    {
        Id = Guid.Parse(input: "06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"),
        Name = "Algorithms",
        Abbr = "IAL",
        Credits = 5,
    };

    public static readonly SubjectEntity SubjectEntity = new()
    {
        Id = Guid.Parse(input: "df935095-8709-4040-a2bb-b6f97cb416dc"),
        Name = "Seminar C#",
        Abbr = "ICS",
        Credits = 4,
    };
}
