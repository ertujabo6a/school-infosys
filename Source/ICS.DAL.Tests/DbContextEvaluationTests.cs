using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.DAL.Tests;
public class SbContextEvaluationTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddNew_Evaluation_Persisted()
    {
        // Arrange
        var entity = EvaluationSeeds.EmptyEvaluationEntity with
        {
            Id = Guid.Parse(input: "07b4cc7e-43aa-48ea-a829-f653c56c6729"),
            ActivityId = ActivitySeeds.ActivityInEvaluation.Id,
            StudentId = StudentSeeds.StudentInEvaluation.Id,
            Points = 2,
            Description = "Bad"
        };

        // Act
        IcsDbContextSut.Evaluations.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = DbContextFactory.CreateDbContext();
        var actual = await dbx.Evaluations.SingleAsync(e => e.Id == entity.Id);
        DeepAssert.Equal(entity, actual);
    }

    [Fact]
    public async Task GetAll_Evaluations_ContainEvaluationEntity()
    {
        // Arrange
        var entities = await IcsDbContextSut.Evaluations.ToArrayAsync();

        // Assert
        var contains = entities.Any(e =>
            e.Id == EvaluationSeeds.EvaluationEntity.Id &&
            e.ActivityId == EvaluationSeeds.EvaluationEntity.ActivityId &&
            e.Activity == EvaluationSeeds.EvaluationEntity.Activity &&
            e.StudentId == EvaluationSeeds.EvaluationEntity.StudentId &&
            e.Student == EvaluationSeeds.EvaluationEntity.Student &&
            e.Points == EvaluationSeeds.EvaluationEntity.Points &&
            e.Description == EvaluationSeeds.EvaluationEntity.Description
        );
        Assert.True(contains);
    }

    [Fact]
    public async Task GetById_Evaluation_EvaluationEntityRetrieved()
    {
        // Act
        var entity = await IcsDbContextSut.Evaluations.SingleAsync(e => e.Id == EvaluationSeeds.EvaluationEntity.Id);

        // Assert
        DeepAssert.Equal(EvaluationSeeds.EvaluationEntity, entity);
    }

    [Fact]
    public async Task GetByActivity_Evaluation_EvaluationEntityRetrieved()
    {
        // Act
        var entity = await IcsDbContextSut.Evaluations.SingleAsync(e => e.ActivityId == ActivitySeeds.ActivityInEvaluation.Id);

        // Assert
        DeepAssert.Equal(EvaluationSeeds.EvaluationEntity, entity);
    }

    [Fact]
    public async Task Update_Evaluation_Persisted()
    {
        // Arrange
        var entity = EvaluationSeeds.EvaluationEntity with { Description = "Updated description" };

        // Act
        IcsDbContextSut.Evaluations.Update(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = DbContextFactory.CreateDbContext();
        var actual = await dbx.Evaluations.SingleAsync(e => e.Id ==  entity.Id);
        DeepAssert.Equal(entity, actual);
    }

    [Fact]
    public async Task Delete_Evaluation_Removed()
    {
        // Arrange
        var entity = EvaluationSeeds.EvaluationEntity;

        // Act
        IcsDbContextSut.Evaluations.Remove(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = DbContextFactory.CreateDbContext();
        var actual = await dbx.Evaluations.SingleOrDefaultAsync(e  => e.Id == entity.Id);
        Assert.Null(actual);
    }

    [Fact]
    public async Task DeleteById_Evaluation_Removed()
    {
        // Arrange
        var entity = EvaluationSeeds.EvaluationEntity;

        // Act
        IcsDbContextSut.Remove(IcsDbContextSut.Evaluations.Single(e => e.Id == entity.Id));
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = DbContextFactory.CreateDbContext();
        var actual = await dbx.Evaluations.SingleOrDefaultAsync(e => e.Id == entity.Id);
        Assert.Null(actual);
    }
}
