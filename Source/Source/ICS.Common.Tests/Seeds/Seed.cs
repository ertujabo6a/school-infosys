using Microsoft.EntityFrameworkCore;
using ICS.DAL.Entities;
namespace ICS.Common.Tests.Seeds;

public static class Seed
{
    public static void WithSamples(ModelBuilder builder)
    {
        builder.Entity<StudentEntity>()
            .HasData(
                StudentSeeds.StudentEntity,
                StudentSeeds.StudentInEvaluation
            );

        builder.Entity<SubjectEntity>()
            .HasData(
                SubjectSeeds.SubjectEntity,
                SubjectSeeds.SubjectForActivity
            );

        builder.Entity<ActivityEntity>()
            .HasData(
                ActivitySeeds.ActivityEntity,
                ActivitySeeds.ActivityInEvaluation
            );

        builder.Entity<EvaluationEntity>()
            .HasData(
                EvaluationSeeds.EvaluationEntity
            );
    }

}
