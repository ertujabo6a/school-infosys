using System.Runtime.InteropServices.JavaScript;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class EvaluationSeeds
{
    public static readonly EvaluationEntity EmptyEvaluationEntity = new()
    {
        Id = default,
        StudentId = default,
        Student = default!,
        ActivityId = default,
        Activity = default!,
        Points = default,
        Description = default,
    };

    public static readonly EvaluationEntity EvaluationEntity = new()
    {
        Id = Guid.Parse("07b4cc7e-43aa-48ea-a829-f653c56c6728"),
        StudentId = StudentSeeds.StudentInEvaluation.Id,
        Student = StudentSeeds.StudentInEvaluation,
        ActivityId = ActivitySeeds.ActivityInEvaluation.Id,
        Activity = ActivitySeeds.ActivityInEvaluation,
        Points = 4,
        Description = "Good job",
    };
}
