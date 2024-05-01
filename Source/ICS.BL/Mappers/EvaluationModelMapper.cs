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
            Activity = entity.Activity != null ? entity.Activity.Type : 0,
            StudentId = entity.StudentId,
            StudentName = entity.Student != null ? entity.Student.Name : string.Empty,
            StudentSurname = entity.Student != null ? entity.Student.Surname : string.Empty,
            Points = entity.Points,
        };

    public override EvaluationDetailModel MapToDetailModel(EvaluationEntity? entity)
        => entity is null
            ? EvaluationDetailModel.Empty
            : new EvaluationDetailModel
            {
                Id = entity.Id,
                ActivityId = entity.ActivityId,
                Activity = entity.Activity != null ? entity.Activity.Type : 0,
                StudentId = entity.StudentId,
                StudentName = entity.Student != null ? entity.Student.Name : string.Empty,
                StudentSurname = entity.Student != null ? entity.Student.Surname : string.Empty,
                SubjectId = entity.Activity != null ? entity.Activity.Subject.Id : Guid.Empty,
                SubjectAbbr = entity.Activity != null ? entity.Activity.Subject.Abbr : string.Empty,
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
