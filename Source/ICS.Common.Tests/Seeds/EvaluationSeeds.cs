using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class EvaluationSeeds
{
    private static readonly EvaluationEntity EvaluationTestEntity = new()
    {
        Id = default,
        StudentId = default,
        Student = null!,
        ActivityId = default,
        Activity = null!,
        Points = 4,
        Description = "Description",
    };

    public static readonly EvaluationEntity EvaluationEntity_EvaluationTest_GetAll =
        EvaluationTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000028"),
            StudentId = StudentSeeds.StudentEntity_EvaluationTest_GetAll.Id,
            ActivityId = ActivitySeeds.ActivityEntity_EvaluationTest_GetAll.Id
        };
    public static readonly EvaluationEntity EvaluationEntity_EvaluationTest_GetByStudent =
        EvaluationTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000029"),
            StudentId = StudentSeeds.StudentEntity_EvaluationTest_GetByStudent.Id,
            ActivityId = ActivitySeeds.ActivityEntity_EvaluationTest_GetByStudent.Id
        };
    public static readonly EvaluationEntity EvaluationEntity_EvaluationTest_Update =
        EvaluationTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000002a"),
            StudentId = StudentSeeds.StudentEntity_EvaluationTest_Update.Id,
            ActivityId = ActivitySeeds.ActivityEntity_EvaluationTest_Update.Id
        };
    public static readonly EvaluationEntity EvaluationEntity_EvaluationTest_Delete =
        EvaluationTestEntity with
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000002b"),
            StudentId = StudentSeeds.StudentEntity_EvaluationTest_Delete.Id,
            ActivityId = ActivitySeeds.ActivityEntity_EvaluationTest_Delete.Id
        };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<EvaluationEntity>().HasData(
            EvaluationEntity_EvaluationTest_GetAll,
            EvaluationEntity_EvaluationTest_GetByStudent,
            EvaluationEntity_EvaluationTest_Update,
            EvaluationEntity_EvaluationTest_Delete);
}
