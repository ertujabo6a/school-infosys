using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.DAL.Tests;
public class DbContextSubjectTest(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddNew_Subject_Persisted()
    {
        // Arrange
        var entity = new SubjectEntity
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-3d96cc2cbf99"),
            Name = "New subject",
            Abbr = "NS",
            Credits = 10
        };

        // Act
        IcsDbContextSut.Subjects.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbContext = DbContextFactory.CreateDbContext();
        var actualEntity = await dbContext.Subjects.SingleAsync(s => s.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task GetAll_Subject_ContainsSeededSubject()
    {
        // Act
        var entities = await IcsDbContextSut.Subjects.ToArrayAsync();

        // Assert
        DeepAssert.Contains(SubjectSeeds.SubjectEntity_SubjectTest_GetAll, entities);
    }

    [Fact]
    public async Task GetById_Subject()
    {
        // Act
        var entity = await IcsDbContextSut.Subjects.SingleAsync(i => i.Id == SubjectSeeds.SubjectEntity_SubjectTest_GetById.Id);

        // Assert
        DeepAssert.Equal(SubjectSeeds.SubjectEntity_SubjectTest_GetById, entity);
    }

    [Fact]
    public async Task Update_Subject_Persisted()
    {
        // Arrange
        var baseEntity = SubjectSeeds.SubjectEntity_SubjectTest_Update;
        var entity = baseEntity with
        {
            Name = "Updated Name",
        };

        // Act
        IcsDbContextSut.Subjects.Update(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.Subjects.SingleAsync(i => i.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task Delete_Subject()
    {
        // Arrange
        var entityBase = SubjectSeeds.SubjectEntity_SubjectTest_Delete;

        // Act
        IcsDbContextSut.Subjects.Remove(entityBase);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        Assert.False(await IcsDbContextSut.Subjects.AnyAsync(i => i.Id == entityBase.Id));
    }

    [Fact]
    public async Task DeleteById_Subject()
    {
        // Arrange
        var entityBase = SubjectSeeds.SubjectEntity_SubjectTest_DeleteById;

        // Act
        IcsDbContextSut.Subjects.Remove(IcsDbContextSut.Subjects.Single(i => i.Id == entityBase.Id));
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        Assert.False(await IcsDbContextSut.Subjects.AnyAsync(i => i.Id == entityBase.Id));
    }
}
