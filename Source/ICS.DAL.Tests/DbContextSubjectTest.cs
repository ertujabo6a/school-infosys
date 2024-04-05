using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.DAL.Tests;
public class DbContextSubjectTest (ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddNew_Subject_Persisted()
    {
        // Arrange
        var entity = SubjectSeeds.EmptySubjectEntity with
        {
            Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9c49"),
            Name = "Seminář C#",
            Abbr = "ICS",
            Credits = 4
        };

        // Act
        IcsDbContextSut.Subjects.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var DbContext = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await DbContext.Subjects
            .SingleAsync(i => i.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task GetAll_Subjects_ContainsSubjectEntity()
    {
        // Arrange
        var entities = await IcsDbContextSut.Subjects.ToArrayAsync();

        // Assert
        bool contains = entities.Any(e =>
            e.Id == SubjectSeeds.SubjectEntity.Id &&
            e.Name == SubjectSeeds.SubjectEntity.Name &&
            e.Abbr == SubjectSeeds.SubjectEntity.Abbr &&
            e.Credits == SubjectSeeds.SubjectEntity.Credits
            );
        Assert.True(contains);
    }

    [Fact]
    public async Task GetById_Subject()
    {
        // Act
        var entity = await IcsDbContextSut.Subjects.SingleAsync(e => e.Id == SubjectSeeds.SubjectEntity.Id);

        // Assert
        DeepAssert.Equal(SubjectSeeds.SubjectEntity, entity);
    }

    [Fact]
    public async Task GetById_IncludingActivities_Subject()
    {
        // Act
        var entity = await IcsDbContextSut.Subjects
            .Include(i => i.Activities)
            .SingleAsync(i => i.Id == SubjectSeeds.SubjectEntity.Id);

        // Assert
        DeepAssert.Equal(SubjectSeeds.SubjectEntity, entity);
    }

    [Fact]
    public async Task Update_Subject_Persisted()
    {
        // Arrange
        var entity = SubjectSeeds.SubjectEntity with { Name = "Updated name" };

        // Act
        IcsDbContextSut.Subjects.Update(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        var actual = await dbContext.Subjects.SingleAsync(e => e.Id == entity.Id);
        DeepAssert.Equal(entity, actual);
    }

    [Fact]
    public async Task Delete_Subject_Removed()
    {
        // Arrange
        var entity = SubjectSeeds.SubjectEntity;

        // Act
        IcsDbContextSut.Subjects.Remove(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        var actual = await dbContext.Subjects.SingleOrDefaultAsync(e => e.Id == entity.Id);
        Assert.Null(actual);
    }

    [Fact]
    public async Task DelelteById_Subject_Removed()
    {
        // Arrange
        var entity = SubjectSeeds.SubjectEntity;

        // Act
        IcsDbContextSut.Remove(IcsDbContextSut.Subjects.Single(e => e.Id == entity.Id));
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        var actual = await dbContext.Subjects.SingleOrDefaultAsync(e => e.Id == entity.Id);
        Assert.Null(actual);
    }

    [Fact]
    public async Task Delete_SujectWithActivity_Removed()
    {
        // Arrange
        var entity = SubjectSeeds.SubjectForActivity;
        var activity = ActivitySeeds.ActivityEntity;

        // Act
        IcsDbContextSut.Remove(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        var actual = await dbContext.Activities.SingleOrDefaultAsync(e => e.Id == activity.Id);
        Assert.Null(actual);
    }

}
