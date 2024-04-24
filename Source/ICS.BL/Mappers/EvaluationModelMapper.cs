using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;
using ICS.Common.Tests.Seeds;



namespace ICS.BL.Mappers;

public class EvaluationModelMapper
    : ModelMapperBase<EvaluationEntity, EvaluationListModel, EvaluationDetailModel>,
    IEvaluationModelMapper
{
    public override EvaluationListModel MapToListModel(EvaluationEntity? entity)
        => entity is null
        ? EvaluationListModel.Empty
        : new EvaluationListModel
        {
            Id = entity.Id,
            Points = entity.Points,
            StudentId = entity.StudentId,
            ActivityId = entity.ActivityId
        };

    public override EvaluationDetailModel MapToDetailModel(EvaluationEntity? entity)
        => entity is null
            ? EvaluationDetailModel.Empty
            : new EvaluationDetailModel
            {
                Id = entity.Id,
                ActivityId = entity.ActivityId,
                StudentId = entity.StudentId,
                Points = entity.Points,
                Description = entity.Description
            };

    public override EvaluationEntity MapToEntity(EvaluationDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            Description = detailModel.Description,
            Points = detailModel.Points,
            ActivityId = detailModel.ActivityId,
            StudentId = detailModel.StudentId,
            Activity = null!,
            Student = null!
        };

}
