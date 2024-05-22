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
    public async Task SaveNew_Evaluation_DoesNotThrow()
    {
        var model = new EvaluationDetailModel()
        {
            Id = Guid.Parse("fab130cd-eefe-443f-baf6-110000001111"),
            Description = "Description 1",
            Points = 5,
            StudentId = StudentSeeds.StudentEntity_BL_EvaluationTest_AddNew.Id,
            StudentName = StudentSeeds.StudentEntity_BL_EvaluationTest_AddNew.Name,
            StudentSurname = StudentSeeds.StudentEntity_BL_EvaluationTest_AddNew.Surname,
            SubjectId = SubjectSeeds.SubjectEntity_BL_EvaluationTest_AddNew.Id,
            SubjectAbbr = SubjectSeeds.SubjectEntity_BL_EvaluationTest_AddNew.Abbr,
            ActivityId = ActivitySeeds.ActivityEntity_BL_EvaluationTest_AddNew.Id,
            Activity = ActivitySeeds.ActivityEntity_BL_EvaluationTest_AddNew.Type
        };

        var _ = await _evaluationFacadeSUT.SaveAsync(model);
    }

    [Fact]
    public async Task GetAll_Single_SeededEvaluation()
    {
        var evaluations = await _evaluationFacadeSUT.GetAsync();
        var evaluation = evaluations.Single(e => e.Id == EvaluationSeeds.EvaluationEntity_BL_EvaluationTest_GetAll.Id);

        DeepAssert.Equal(EvaluationModelMapper.MapToListModel(EvaluationSeeds.EvaluationEntity_BL_EvaluationTest_GetAll), evaluation);
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
        await _evaluationFacadeSUT.DeleteAsync(EvaluationSeeds.EvaluationEntity_BL_EvaluationTest_Delete.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Evaluations.AnyAsync(e => e.Id == EvaluationSeeds.EvaluationEntity_BL_EvaluationTest_Delete.Id));
    }

    [Fact]
    public async Task Insert_NewEvaluation_Added()
    {
        var model = new EvaluationDetailModel()
        {
            Id = Guid.Empty,
            Description = "Description 1",
            Points = 5,
            StudentId = StudentSeeds.StudentEntity_BL_EvaluationTest_AddNew.Id,
            StudentName = StudentSeeds.StudentEntity_BL_EvaluationTest_AddNew.Name,
            StudentSurname = StudentSeeds.StudentEntity_BL_EvaluationTest_AddNew.Surname,
            SubjectId = SubjectSeeds.SubjectEntity_BL_EvaluationTest_AddNew.Id,
            SubjectAbbr = SubjectSeeds.SubjectEntity_BL_EvaluationTest_AddNew.Abbr,
            ActivityId = ActivitySeeds.ActivityEntity_BL_EvaluationTest_AddNew.Id,
            Activity = ActivitySeeds.ActivityEntity_BL_EvaluationTest_AddNew.Type
        };

        var savedModel = await _evaluationFacadeSUT.SaveAsync(model);
        model.Id = savedModel.Id;

        var evaluation = await _evaluationFacadeSUT.GetAsync(savedModel.Id);
        DeepAssert.Equal(model, evaluation);
    }

    [Fact]
    public async Task Update_ExistingEvaluation__Updated()
    {
        var model = EvaluationModelMapper.MapToDetailModel(EvaluationSeeds.EvaluationEntity_BL_EvaluationTest_Update);
        model.SubjectId = SubjectSeeds.SubjectEntity_BL_EvaluationTest_Update.Id;

        var savedModel = await _evaluationFacadeSUT.SaveAsync(model);

        var modelFromDB = await _evaluationFacadeSUT.GetAsync(savedModel.Id);

        Assert.NotNull(modelFromDB);

        var updatedModel = modelFromDB with
        {
            Description = "Updated description",
            Points = 100
        };

        var savedUpdatedModel = await _evaluationFacadeSUT.SaveAsync(updatedModel);

        var evaluation = await _evaluationFacadeSUT.GetAsync(savedUpdatedModel.Id);
        Assert.Equal(updatedModel, evaluation);
    }


}
