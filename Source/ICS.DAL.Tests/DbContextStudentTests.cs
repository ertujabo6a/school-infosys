using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.DAL.Tests;

public class DbContextStudentTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddNew_Student_Persisted()
    {
        // Arrange
        var entity = new StudentEntity
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-3d96cc2cbf23"),
            Name = "Petr",
            Surname = "Pavel",
            ImageUrl = "https://example.com/photo.jpg"
        };

        // Act
        IcsDbContextSut.Students.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbContext = DbContextFactory.CreateDbContext();
        var actualEntity = await dbContext.Students.SingleAsync(s => s.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task GetAll_Students_ContainsSeededStudent()
    {
        // Act
        var entities = await IcsDbContextSut.Students.ToArrayAsync();

        // Assert
        DeepAssert.Contains(StudentSeeds.StudentEntity_StudentTest_GetAll, entities);
    }

    [Fact]
    public async Task GetById_Student_StudentEntity()
    {
        // Act
        var entity = await IcsDbContextSut.Students.SingleAsync(i => i.Id == StudentSeeds.StudentEntity_StudentTest_GetById.Id);

        // Assert
        DeepAssert.Equal(StudentSeeds.StudentEntity_StudentTest_GetById, entity);
    }

    [Fact]
    public async Task Update_Student_Persisted()
    {
        // Arrange
        var baseEntity = StudentSeeds.StudentEntity_StudentTest_Update;
        var entity = baseEntity with
        {
            Name = "Updated Name",
            Surname = "Updated Surname"
        };

        // Act
        IcsDbContextSut.Students.Update(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.Students.SingleAsync(i => i.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task Delete_Student_StudentDelete1()
    {
        // Arrange
        var entityBase = StudentSeeds.StudentEntity_StudentTest_Delete1;

        // Act
        IcsDbContextSut.Students.Remove(entityBase);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        Assert.False(await IcsDbContextSut.Students.AnyAsync(i => i.Id == entityBase.Id));
    }

    [Fact]
    public async Task DeleteById_Student_StudentDelete2()
    {
        // Arrange
        var entityBase = StudentSeeds.StudentEntity_StudentTest_Delete2;

        // Act
        IcsDbContextSut.Students.Remove(IcsDbContextSut.Students.Single(i => i.Id == entityBase.Id));
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        Assert.False(await IcsDbContextSut.Students.AnyAsync(i => i.Id == entityBase.Id));
    }
}
