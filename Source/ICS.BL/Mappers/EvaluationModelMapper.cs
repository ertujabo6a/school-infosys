using System;
using System.Collections.ObjectModel;
using ICS.BL.Models;
using ICS.BL.Entities;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class EvaluationModelMapper
    : ModelMapperBase<EvaluationEntity, EvaluationListModel, EvaluationReferenceModel>,
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

}
