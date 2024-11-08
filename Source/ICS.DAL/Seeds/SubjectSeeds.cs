﻿using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.DAL.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity Ics = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2d"),
        Name = "The C# programming language",
        Abbr = "ICS",
        Credits = 4,
    };

    static SubjectSeeds()
    {
        Ics.Activities.Add(ActivitySeeds.IcsLecture);
    }

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<SubjectEntity>().HasData(
            Ics with
            {
                Activities = Array.Empty<ActivityEntity>(),
                StudentToSubjects = Array.Empty<StudentToSubjectEntity>()
            });
}
