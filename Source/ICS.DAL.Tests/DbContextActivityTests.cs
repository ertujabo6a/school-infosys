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
        var newActivity = new ActivityEntity
        {
            Id = Guid.Parse("47b4cc7e-43aa-48ea-e829-f653c56c0006"),
            Type = ActivityType.Lecture,
            Room = Room.D105,
            StartTime = new DateTime(2024, 1, 1, 12, 0, 0),
            EndTime = new DateTime(2024, 1, 1, 13, 0, 0),
            Subject = null!,
            SubjectId = SubjectSeeds.SubjectEntity_ActivityTest_AddNew.Id
        };

        // Act
        await IcsDbContextSut.Activities.AddAsync(newActivity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbContext = DbContextFactory.CreateDbContext();
        var actualEntity = await dbContext.Activities.SingleAsync(s => s.Id == newActivity.Id);
        DeepAssert.Equal(newActivity, actualEntity);
    }

    [Fact]
    public async Task GetById_Activity()
    {
        // Act
        var entity = await IcsDbContextSut.Activities.SingleAsync(i => i.Id == ActivitySeeds.ActivityEntity_ActivityTest_GetById.Id);

        // Assert
        DeepAssert.Equal(ActivitySeeds.ActivityEntity_ActivityTest_GetById, entity);
    }

    [Fact]
    public async Task Update_Activity_Persisted()
    {
        // Arrange
        var baseEntity = ActivitySeeds.ActivityEntity_ActivityTest_Update;
        var entity = baseEntity with
        {
            Type = ActivityType.Seminar
        };

        // Act
        IcsDbContextSut.Activities.Update(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.Activities.SingleAsync(i => i.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task Delete_Activity()
    {
        // Arrange
        var entityBase = ActivitySeeds.ActivityEntity_ActivityTest_Delete;

        // Act
        IcsDbContextSut.Activities.Remove(entityBase);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        Assert.False(await IcsDbContextSut.Activities.AnyAsync(i => i.Id == entityBase.Id));
    }
}
