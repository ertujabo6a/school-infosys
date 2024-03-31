using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class EvaluationModelMapper
    : ModelMapperBase2<EvaluationEntity, EvaluationListModel>,
    IEvaluationModelMapper
{
    public override EvaluationListModel MapToListModel(EvaluationEntity? entity)
        => entity is null
        ? EvaluationListModel.Empty
        : new EvaluationListModel
        {
            Id = entity.Id,
            Description = entity.Description,
            Points = entity.Points
        };

    public override EvaluationEntity MapToEntity(EvaluationListModel list_model)
        => new()
        {
            Id = list_model.Id,
            Description = list_model.Description,
            Points = list_model.Points,
            ActivityId = default,
            StudentId = default,
            Activity = null!,
            Student = null!
        };

}
