using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity IcsLecture = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2a"),
        Type = Common.Enums.ActivityType.Lecture,
        Room = Common.Enums.Room.E112,
        StartTime = new DateTime(2024, 2, 20, 12, 0, 0),
        EndTime = new DateTime(2024, 2, 20, 13, 50, 0),

        Subject = SubjectSeeds.Ics,
        SubjectId = SubjectSeeds.Ics.Id
    };

    static ActivitySeeds() => IcsLecture.Evaluations.Add(EvaluationSeeds.IcsEvaluation);

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ActivityEntity>().HasData(IcsLecture);
}
