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

    public static readonly SubjectEntity SubjectEntity_BL_SubjectTest_GetAll =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000001") };
    public static readonly SubjectEntity SubjectEntity_BL_SubjectTest_DeleteById =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000002") };
    public static readonly SubjectEntity SubjectEntity_BL_SubjectTest_Delete =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000003") };
    public static readonly SubjectEntity SubjectEntity_BL_SubjectTest_Delete_SubjectUsedInActivity =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000004") };
    public static readonly SubjectEntity SubjectEntity_BL_SubjectTest_Update =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000005") };
    public static readonly SubjectEntity SubjectEntity_BL_StudentTest_UpdateWithSideColl =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000006"), Abbr = "IFN"};

    public static readonly SubjectEntity SubjectEntity_BL_ActivityTest_GetById =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000007") };
    public static readonly SubjectEntity SubjectEntity_BL_ActivityTest_DeleteById =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000008") };
    public static readonly SubjectEntity SubjectEntity_BL_ActivityTest_Insert =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000009") };

    public static readonly SubjectEntity SubjectEntity_BL_EvaluationTest_AddNew =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-100000000019") };
    public static readonly SubjectEntity SubjectEntity_BL_EvaluationTest_GetAll =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-10000000001a") };
    public static readonly SubjectEntity SubjectEntity_BL_EvaluationTest_GetByStudent =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-10000000001b") };
    public static readonly SubjectEntity SubjectEntity_BL_EvaluationTest_Update =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-10000000001c") };
    public static readonly SubjectEntity SubjectEntity_BL_EvaluationTest_Delete =
        SubjectTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-10000000001d") };


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
            SubjectEntity_EvaluationTest_Delete,

            SubjectEntity_BL_SubjectTest_GetAll,
            SubjectEntity_BL_SubjectTest_DeleteById,
            SubjectEntity_BL_SubjectTest_Delete,
            SubjectEntity_BL_SubjectTest_Delete_SubjectUsedInActivity,
            SubjectEntity_BL_SubjectTest_Update,
            SubjectEntity_BL_StudentTest_UpdateWithSideColl,
            SubjectEntity_BL_ActivityTest_GetById,
            SubjectEntity_BL_ActivityTest_DeleteById,
            SubjectEntity_BL_ActivityTest_Insert,

            SubjectEntity_BL_EvaluationTest_AddNew,
            SubjectEntity_BL_EvaluationTest_GetAll,
            SubjectEntity_BL_EvaluationTest_GetByStudent,
            SubjectEntity_BL_EvaluationTest_Update,
            SubjectEntity_BL_EvaluationTest_Delete);
}
