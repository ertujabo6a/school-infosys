using System.Runtime.InteropServices.JavaScript;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS.Common.Tests.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity EmptyStudentEntity = new()
    {
        Id = default,
        Name = default!,
        Surname = default!,
        ImageUrl = default,
    };

    public static readonly StudentEntity StudentEntity = new()
    {
        Id = Guid.Parse("07b4cc7e-43aa-48ea-a829-f653c56c6728"),
        Name = "Jan",
        Surname = "Novak",
        ImageUrl = "https://example.com/images/jan.jpg"
    };

    public static readonly StudentEntity StudentInEvaluation = new()
    {
        Id = Guid.Parse("07b4cc7e-43aa-48ea-a829-f653c56c6729"),
        Name = "John",
        Surname = "Johnson",
        ImageUrl = "https://example.com/images/john.jpg"
    };

}
