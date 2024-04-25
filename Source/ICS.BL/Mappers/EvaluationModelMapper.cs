using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

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
            ActivityId = entity.ActivityId,
            Activity = entity.Activity.Type,
            StudentId = entity.StudentId,
            StudentName = entity.Student.Name,
            StudentSurname = entity.Student.Surname,
            Points = entity.Points,
        };

    public override EvaluationDetailModel MapToDetailModel(EvaluationEntity? entity)
        => entity is null
            ? EvaluationDetailModel.Empty
            : new EvaluationDetailModel
            {
                Id = entity.Id,
                ActivityId = entity.ActivityId,
                Activity = entity.Activity.Type,
                StudentId = entity.StudentId,
                StudentName = entity.Student.Name,
                StudentSurname = entity.Student.Surname,
                SubjectId = entity.Activity.Subject.Id,
                SubjectAbbr = entity.Activity.Subject.Abbr,
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
