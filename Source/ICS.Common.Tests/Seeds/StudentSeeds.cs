using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class StudentSeeds
{
    private static readonly StudentEntity StudentTestEntity = new()
    {
        Id = default,
        Name = "Name",
        Surname = "Surname",
        ImageUrl = "https://example.com/images/jan.jpg"
    };

    public static readonly StudentEntity StudentEntity_StudentTest_GetAll =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000000") };
    public static readonly StudentEntity StudentEntity_StudentTest_GetById =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000001") };
    public static readonly StudentEntity StudentEntity_StudentTest_Update =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000002") };
    public static readonly StudentEntity StudentEntity_StudentTest_Delete1 =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000003") };
    public static readonly StudentEntity StudentEntity_StudentTest_Delete2 =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000004") };
    public static readonly StudentEntity StudentEntity_EvaluationTest_AddNew =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000008") };
    public static readonly StudentEntity StudentEntity_EvaluationTest_GetAll =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-000000000009") };
    public static readonly StudentEntity StudentEntity_EvaluationTest_GetByStudent =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000000a") };
    public static readonly StudentEntity StudentEntity_EvaluationTest_Update =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000000b") };
    public static readonly StudentEntity StudentEntity_EvaluationTest_Delete =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-00000000000c") };

    public static readonly StudentEntity StudentEntity_BL_StudentTest_GetById =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-010000000001") };
    public static readonly StudentEntity StudentEntity_BL_StudentTest_GetAll =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-010000000002") };
    public static readonly StudentEntity StudentEntity_BL_StudentTest_Delete =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-010000000003") };
    public static readonly StudentEntity StudentEntity_BL_StudentTest_Update =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-010000000004") };
    public static readonly StudentEntity StudentEntity_BL_StudentTest_UpdateWithSideColl =
        StudentTestEntity with { Id = Guid.Parse("fab130cd-eefe-443f-baf6-010000000005") };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            StudentEntity_StudentTest_GetAll,
            StudentEntity_StudentTest_GetById,
            StudentEntity_StudentTest_Update,
            StudentEntity_StudentTest_Delete1,
            StudentEntity_StudentTest_Delete2,
            StudentEntity_EvaluationTest_AddNew,
            StudentEntity_EvaluationTest_GetAll,
            StudentEntity_EvaluationTest_GetByStudent,
            StudentEntity_EvaluationTest_Update,
            StudentEntity_EvaluationTest_Delete,

            StudentEntity_BL_StudentTest_GetById,
            StudentEntity_BL_StudentTest_GetAll,
            StudentEntity_BL_StudentTest_Delete,
            StudentEntity_BL_StudentTest_Update,
            StudentEntity_BL_StudentTest_UpdateWithSideColl);
    }
}
