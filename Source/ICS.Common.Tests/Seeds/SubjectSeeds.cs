using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class SubjectSeeds
{
    private static readonly SubjectEntity SubjectTestEntity = new()
    {
        Id = default,
        Name = "SubjectName",
        Abbr = "SubjectAbbr",
        Credits = 4,
    };

    public static readonly SubjectEntity SubjectEntity_SubjectTest_GetAll =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000000d") };
    public static readonly SubjectEntity SubjectEntity_SubjectTest_GetById =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000000e") };
    public static readonly SubjectEntity SubjectEntity_SubjectTest_Update =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000000f") };
    public static readonly SubjectEntity SubjectEntity_SubjectTest_Delete =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000010") };
    public static readonly SubjectEntity SubjectEntity_SubjectTest_DeleteById =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000011") };
    public static readonly SubjectEntity SubjectEntity_ActivityTest_AddNew =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000012") };
    public static readonly SubjectEntity SubjectEntity_ActivityTest_GetById =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000013") };
    public static readonly SubjectEntity SubjectEntity_ActivityTest_Update =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000014") };
    public static readonly SubjectEntity SubjectEntity_ActivityTest_Delete =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000015") };
    public static readonly SubjectEntity SubjectEntity_EvaluationTest_AddNew =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000019") };
    public static readonly SubjectEntity SubjectEntity_EvaluationTest_GetAll =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000001a") };
    public static readonly SubjectEntity SubjectEntity_EvaluationTest_GetByStudent =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000001b") };
    public static readonly SubjectEntity SubjectEntity_EvaluationTest_Update =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000001c") };
    public static readonly SubjectEntity SubjectEntity_EvaluationTest_Delete =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000001d") };


    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<SubjectEntity>().HasData(
            SubjectEntity_SubjectTest_GetAll,
            SubjectEntity_SubjectTest_GetById,
            SubjectEntity_SubjectTest_Update,
            SubjectEntity_SubjectTest_Delete,
            SubjectEntity_SubjectTest_DeleteById,
            SubjectEntity_ActivityTest_AddNew,
            SubjectEntity_ActivityTest_GetById,
            SubjectEntity_ActivityTest_Update,
            SubjectEntity_ActivityTest_Delete,
            SubjectEntity_EvaluationTest_AddNew,
            SubjectEntity_EvaluationTest_GetAll,
            SubjectEntity_EvaluationTest_GetByStudent,
            SubjectEntity_EvaluationTest_Update,
            SubjectEntity_EvaluationTest_Delete);
}
