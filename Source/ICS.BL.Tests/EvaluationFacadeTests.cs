using ICS.BL.Facades.Interfaces;
using ICS.BL.Facades;
using ICS.BL.Models;
using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.BL.Tests;

public sealed class EvaluationFacadeTests : FacadeTestsBase
{
    private readonly IEvaluationFacade _evaluationFacadeSUT;

    public EvaluationFacadeTests(ITestOutputHelper output) : base(output)
    {
        _evaluationFacadeSUT = new EvaluationFacade(UnitOfWorkFactory, EvaluationModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new EvaluationListModel()
        {
            Id = Guid.Empty,
            Description = "Description 1",
            Points = 5
        };

        var _ = await _evaluationFacadeSUT.SaveAsync(model);
    }

    [Fact]
    public async Task GetAll_Single_SeededEvaluation()
    {
        var evaluations = await _evaluationFacadeSUT.GetAsync();
        var evaluation = evaluations.Single(e => e.Id == EvaluationSeeds.EvaluationEntity.Id);

        DeepAssert.Equal(EvaluationModelMapper.MapToListModel(EvaluationSeeds.EvaluationEntity), evaluation);
    }

    [Fact]
    public async Task GetById_NonExistent()
    {
        var evaluation = await _evaluationFacadeSUT.GetAsync(Guid.NewGuid());

        Assert.Null(evaluation);
    }

    [Fact]
    public async Task DeleteById_SeededEvaluation_Deleted()
    {
        await _evaluationFacadeSUT.DeleteAsync(EvaluationSeeds.EvaluationEntity.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Evaluations.AnyAsync(e => e.Id == EvaluationSeeds.EvaluationEntity.Id));
    }

    [Fact]
    public async Task Insert_NewEvaluation_Added()
    {
        var model = new EvaluationListModel()
        {
            Id = Guid.Empty,
            Description = "Description 1",
            Points = 5
        };

        var savedModel = await _evaluationFacadeSUT.SaveAsync(model);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var evaluation = await dbxAssert.Evaluations.SingleAsync(e => e.Id == savedModel.Id);
        DeepAssert.Equal(savedModel, EvaluationModelMapper.MapToListModel(evaluation));
    }

    [Fact]
    public async Task Update_ExistingEvaluation__Updated()
    {
        var model = EvaluationModelMapper.MapToListModel(EvaluationSeeds.EvaluationEntity);
        model.Points = 10;
        model.Description = "Updated description";

        await _evaluationFacadeSUT.SaveAsync(model);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var evaluation = await dbxAssert.Evaluations.SingleAsync(e => e.Id == EvaluationSeeds.EvaluationEntity.Id);
        DeepAssert.Equal(model, EvaluationModelMapper.MapToListModel(evaluation));
    }


}
