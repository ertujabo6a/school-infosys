using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Seeds;

public static class StudentToSubjectSeeds
{
    public static readonly StudentToSubjectEntity PetrNovakovToIcs = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-1234cc2cbf2a"),
        SubjectId = SubjectSeeds.Ics.Id,
        StudentId = StudentSeeds.PetrNovakov.Id
    };


    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentToSubjectEntity>().HasData(PetrNovakovToIcs);
}
