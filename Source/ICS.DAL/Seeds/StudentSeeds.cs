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

    public static readonly StudentEntity KamilAjajaj = new()
    {
        Id = Guid.Parse("4b3702a3-6e75-473b-882b-1c15face46ea"),
        Name = "Kamil",
        Surname = "Ajajaj"
    };

    static StudentSeeds()
    {
        PetrNovakov.StudentToSubjects.Add(StudentToSubjectSeeds.PetrNovakovToIcs);
        PetrNovakov.Evaluations.Add(EvaluationSeeds.IcsEvaluation);
    }

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentEntity>().HasData(
            PetrNovakov with
            {
                Evaluations = Array.Empty<EvaluationEntity>(),
                StudentToSubjects = Array.Empty<StudentToSubjectEntity>()
            },
            KamilAjajaj with
            {
                Evaluations = Array.Empty<EvaluationEntity>(),
                StudentToSubjects = Array.Empty<StudentToSubjectEntity>()
            });
}
