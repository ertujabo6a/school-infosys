using ICS.Common.Enums;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class ActivitySeeds
{
    private static readonly ActivityEntity ActivityTestEntity = new()
    {
        Id = default,
        Type = ActivityType.Lecture,
        Room = Room.D105,
        StartTime = new DateTime(2024, 1, 1, 12, 0, 0),
        EndTime = new DateTime(2024, 1, 1, 13, 0, 0),
        SubjectId = default,
        Subject = null!
    };

    public static readonly ActivityEntity ActivityEntity_ActivityTest_GetById =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000001e"),
            SubjectId = SubjectSeeds.SubjectEntity_ActivityTest_GetById.Id
        };
    public static readonly ActivityEntity ActivityEntity_ActivityTest_Update =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000001f"),
            SubjectId = SubjectSeeds.SubjectEntity_ActivityTest_Update.Id
        };
    public static readonly ActivityEntity ActivityEntity_ActivityTest_Delete =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000020"),
            SubjectId = SubjectSeeds.SubjectEntity_ActivityTest_Delete.Id
        };
    public static readonly ActivityEntity ActivityEntity_EvaluationTest_AddNew =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000021"),
            SubjectId = SubjectSeeds.SubjectEntity_EvaluationTest_AddNew.Id
        };
    public static readonly ActivityEntity ActivityEntity_EvaluationTest_GetAll =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000022"),
            SubjectId = SubjectSeeds.SubjectEntity_EvaluationTest_GetAll.Id
        };
    public static readonly ActivityEntity ActivityEntity_EvaluationTest_GetByStudent =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000023"),
            SubjectId = SubjectSeeds.SubjectEntity_EvaluationTest_GetByStudent.Id
        };
    public static readonly ActivityEntity ActivityEntity_EvaluationTest_Update =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000024"),
            SubjectId = SubjectSeeds.SubjectEntity_EvaluationTest_Update.Id
        };
    public static readonly ActivityEntity ActivityEntity_EvaluationTest_Delete =
        ActivityTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000025"),
            SubjectId = SubjectSeeds.SubjectEntity_EvaluationTest_Delete.Id
        };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ActivityEntity>().HasData(
            ActivityEntity_ActivityTest_GetById,
            ActivityEntity_ActivityTest_Update,
            ActivityEntity_ActivityTest_Delete,
            ActivityEntity_EvaluationTest_AddNew,
            ActivityEntity_EvaluationTest_GetAll,
            ActivityEntity_EvaluationTest_GetByStudent,
            ActivityEntity_EvaluationTest_Update,
            ActivityEntity_EvaluationTest_Delete);
}
