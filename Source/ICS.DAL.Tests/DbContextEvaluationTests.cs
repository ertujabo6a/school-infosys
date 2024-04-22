using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using ICS.DAL.Entities;
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
        var entity = new EvaluationEntity
        {
            Id = Guid.Parse("07c4cc7e-43aa-48ea-a000-f653c56c6728"),
            StudentId = StudentSeeds.StudentEntity_EvaluationTest_AddNew.Id,
            Student = null!,
            ActivityId = ActivitySeeds.ActivityEntity_EvaluationTest_AddNew.Id,
            Activity = null!,
            Points = 4,
            Description = "Good job",
        };

        // Act
        IcsDbContextSut.Evaluations.Add(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbContext = DbContextFactory.CreateDbContext();
        var actualEntity = await dbContext.Evaluations.SingleAsync(s => s.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task GetAll_Evaluation()
    {
        // Act
        var entities = await IcsDbContextSut.Evaluations.ToArrayAsync();

        // Assert
        DeepAssert.Contains(EvaluationSeeds.EvaluationEntity_EvaluationTest_GetAll, entities);
    }

    [Fact]
    public async Task GetByStudent_Evaluation()
    {
        // Arrange
        var evaluationEntity = EvaluationSeeds.EvaluationEntity_EvaluationTest_GetByStudent;
        var studentEntity = StudentSeeds.StudentEntity_EvaluationTest_GetByStudent;

        // Act
        var entities = await IcsDbContextSut.Evaluations.Where(i => i.StudentId == studentEntity.Id).ToArrayAsync();

        // Assert
        DeepAssert.Contains(evaluationEntity, entities);
    }

    [Fact]
    public async Task Update_Evaluation_Persisted()
    {
        // Arrange
        var baseEntity = EvaluationSeeds.EvaluationEntity_EvaluationTest_Update;
        var entity = baseEntity with
        {
            Points = 100,
            Description = "Updated description"
        };

        // Act
        IcsDbContextSut.Evaluations.Update(entity);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.Evaluations.SingleAsync(i => i.Id == entity.Id);
        DeepAssert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task Delete_Evaluation_EvaluationDelete()
    {
        // Arrange
        var entityBase = EvaluationSeeds.EvaluationEntity_EvaluationTest_Delete;

        // Act
        IcsDbContextSut.Evaluations.Remove(entityBase);
        await IcsDbContextSut.SaveChangesAsync();

        // Assert
        Assert.False(await IcsDbContextSut.Evaluations.AnyAsync(i => i.Id == entityBase.Id));
    }
}
