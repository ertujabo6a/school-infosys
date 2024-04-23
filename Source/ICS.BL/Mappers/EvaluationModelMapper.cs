using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;
using ICS.Common.Tests.Seeds;



namespace ICS.BL.Mappers;

public class EvaluationModelMapper
    : ModelMapperBase<EvaluationEntity, EvaluationDetailModel, EvaluationDetailModel>,
    IEvaluationModelMapper
{
    public override EvaluationDetailModel MapToListModel(EvaluationEntity? entity)
        => entity is null
        ? EvaluationDetailModel.Empty
        : new EvaluationDetailModel
        {
            Id = entity.Id,
            Description = entity.Description,
            Points = entity.Points
        };

    public override EvaluationEntity MapToEntity(EvaluationDetailModel list_model)
        => new()
        {
            Id = list_model.Id,
            Description = list_model.Description,
            Points = list_model.Points,
            ActivityId = ActivitySeeds.ActivityEntity.Id,
            StudentId = StudentSeeds.StudentEntity.Id,
            Activity = null!,
            Student = null!
        };

    public override EvaluationDetailModel MapToReferenceModel(EvaluationEntity? entity) => throw new NotImplementedException();
}
