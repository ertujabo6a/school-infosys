using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Seeds;

public static class EvaluationSeeds
{
    public static readonly EvaluationEntity IcsEvaluation = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2b"),
        Points = 2,

        StudentId = StudentSeeds.PetrNovakov.Id,
        ActivityId = ActivitySeeds.IcsLecture.Id,
    };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<EvaluationEntity>().HasData(IcsEvaluation);
}
