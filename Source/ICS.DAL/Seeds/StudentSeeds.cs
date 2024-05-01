using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity PetrNovakov = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2c"),
        Name = "Petr",
        Surname = "Novakov"
    };

    static StudentSeeds()
    {
        PetrNovakov.Subjects.Add(SubjectSeeds.Ics);
        PetrNovakov.Evaluations.Add(EvaluationSeeds.IcsEvaluation);
    }

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentEntity>().HasData(
            PetrNovakov with
            {
                Evaluations = Array.Empty<EvaluationEntity>(),
                Subjects = Array.Empty<SubjectEntity>()
            });
}
