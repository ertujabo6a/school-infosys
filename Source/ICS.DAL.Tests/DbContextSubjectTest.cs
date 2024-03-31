using ICS.Common.Tests;
using ICS.Common.Tests.Factories;
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
        var entity = SubjectSeeds.EmptySubjectEntity with
        {
            Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9c42"),
            Name = "Seminář C#",
            Abbr = "ICS",
            Credits = 4
        };

        // Act
        IcsDbContextSut.Subjects.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.Subjects
            .SingleAsync(i => i.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task AddNew_SubjectWithActivities_Persisted()
    {
        // Arrange
        var entity = SubjectSeeds.EmptySubjectEntity with
        {
            Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9c42"),
            Name = "Seminář C#",
            Abbr = "ICS",
            Credits = 4,
            Activities = new List<ActivityEntity>
            {
                ActivitySeeds.EmptyActivityEntity with
                {
                    Id = Guid.Parse("fabde0cd-eefe-443f-34f6-3d96cc2cbf42"),
                    Type = Common.Enums.ActivityType.Lecture,
                    Room = Common.Enums.Room.E112,
                    StartTime = new DateTime(2024, 3, 28, 12, 0, 0),
                    EndTime = new DateTime(2024, 4, 28, 13, 50, 0),
                    Description = "Lecture from ICS subject"
                },
                ActivitySeeds.EmptyActivityEntity with
                {
                    Id = Guid.Parse("fabde0cd-eefe-443f-34f6-3d96cc2cbf43"),
                    Type = Common.Enums.ActivityType.Seminar,
                    Room = Common.Enums.Room.D105,
                    StartTime = new DateTime(2024, 3, 28, 14, 0, 0),
                    EndTime = new DateTime(2024, 4, 28, 15, 50, 0),
                    Description = "Seminar from ICS subject"
                }
            }
        };

        // Act
        IcsDbContextSut.Subjects.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.Subjects
            .Include(i => i.Activities)
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

    /*[Fact]
    public async Task Delete_SubjectWithActvities_Removed() 
    {
        // Arrange
        var entity = SubjectSeeds.SubjectEntityWithActivity;
        var activityEntity = ActivitySeeds.ActivityEntity;

        // Act
        IcsDbContextSut.Subjects.Remove(entity);

        // Assert
        await using IcsDbContext dbContext = DbContextFactory.CreateDbContext();
        var actual = await dbContext.Subjects.SingleOrDefaultAsync(e => e.Id == entity.Id);
        Assert.False(await IcsDbContextSut.Subjects.AnyAsync(i => i.Id == entity.Id));
        Assert.False(await IcsDbContextSut.Activities.AnyAsync(i => i.Id == activityEntity.Id));
    }*/
}
