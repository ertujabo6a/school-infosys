using ICS.Common.Enums;
using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.DAL.Tests;

public class DbContextActivityTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddNew_Activity_Persisted()
    {
        // Arrange
        ActivityEntity entity = new()
        {
            Id = Guid.Parse(input: "fab130cd-eefe-443f-baf6-3d96cc2cbf23"),
            Type = ActivityType.Lecture,
            Room = Room.E112,
            StartTime = new DateTime(2024, 3, 28, 12, 0, 0),
            EndTime = new DateTime(2024, 3, 28, 13, 50, 0),
            Description = "ICS Testing Lecture",
            SubjectId = SubjectSeeds.SubjectForActivity.Id,
            Subject = null!
        };

        // Act
        IcsDbContextSut.Activities.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        ActivityEntity actual = await dbContext.Activities.SingleAsync(e => e.Id == entity.Id);
        DeepAssert.Equal(entity, actual, nameof(ActivityEntity.Subject));
    }

    [Fact]
    public async Task GetAll_Activities_ContainsActivityEntity()
    {
        // Act
        var entity = await IcsDbContextSut.Activities.ToArrayAsync();

        // Assert
        Assert.Contains(ActivitySeeds.ActivityEntity, entity);
    }

    [Fact]
    public async Task GetById_Activity_ActivityEntityRetrieved()
    {
        // Act
        ActivityEntity entity = await IcsDbContextSut.Activities.SingleAsync(e => e.Id == ActivitySeeds.ActivityEntity.Id);

        // Assert
        DeepAssert.Equal(ActivitySeeds.ActivityEntity, entity, nameof(ActivityEntity.Subject));
    }

    [Fact]
    public async Task Update_Activity_Persisted()
    {
        // Arrange
        ActivityEntity entity = ActivitySeeds.ActivityEntity with { Description = "Updated Description" };

        // Act
        IcsDbContextSut.Activities.Update(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        ActivityEntity actual = await dbContext.Activities.SingleAsync(e => e.Id == entity.Id);
        DeepAssert.Equal(entity, actual, nameof(ActivityEntity.Subject));
    }

    [Fact]
    public async Task Delete_Activity_Removed()
    {
        // Arrange
        ActivityEntity entity = ActivitySeeds.ActivityEntity;

        // Act
        IcsDbContextSut.Activities.Remove(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        ActivityEntity? actual = await dbContext.Activities.SingleOrDefaultAsync(e => e.Id == entity.Id);
        Assert.Null(actual);
    }

    [Fact]
    public async Task DeleteById_Activity_Removed()
    {
        // Arrange
        ActivityEntity entity = ActivitySeeds.ActivityEntity;

        // Act
        IcsDbContextSut.Remove(
            IcsDbContextSut.Activities.Single(e => e.Id == entity.Id));
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        ActivityEntity? actual = await dbContext.Activities.SingleOrDefaultAsync(e => e.Id == entity.Id);
        Assert.Null(actual);
    }

    /*[Fact]
    public async Task Delete_ActivityUsedInEvaluation_Throws()
    {
        var baseEntity = ActivitySeeds.ActivityInEvaluation;

        IcsDbContextSut.Activities.Remove(baseEntity);

        await Assert.ThrowsAsync<DbUpdateException>(async () => await IcsDbContextSut.SaveChangesAsync());
    }*/

}
