using Microsoft.EntityFrameworkCore;
using ICS.DAL.Entities;
namespace ICS.Common.Tests.Seeds;

public static class Seed
{
    public static void WithSamples(ModelBuilder builder)
    {
        builder.Entity<StudentEntity>()
            .HasData(StudentSeeds.StudentEntity);

        builder.Entity<SubjectEntity>()
            .HasData(SubjectSeeds.SubjectEntity);

        builder.Entity<ActivityEntity>()
            .HasData(ActivitySeeds.ActivityEntity);

        builder.Entity<EvaluationEntity>()
            .HasData(EvaluationSeeds.EvaluationEntity);
    }

}
