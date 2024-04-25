using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class SubjectModelMapper(IStudentModelMapper studentModelMapper, IActivityModelMapper activityModelMapper)
    : ModelMapperBase<SubjectEntity, SubjectListModel, SubjectDetailModel>,
    ISubjectModelMapper
{
    public override SubjectListModel MapToListModel(SubjectEntity? entity)
        => entity is null
            ? SubjectListModel.Empty
            : new SubjectListModel
        {
            Id = entity.Id,
            SubjectAbbr = entity.Abbr,
        };

    public override SubjectDetailModel MapToDetailModel(SubjectEntity? entity)
        => entity is null
            ? SubjectDetailModel.Empty
            : new SubjectDetailModel
        {
            Id = entity.Id,
            SubjectName = entity.Name,
            SubjectAbbr = entity.Abbr,
            Credits = entity.Credits,
            Students = studentModelMapper.MapToListModel(entity.Students).ToObservableCollection(),
            Activities = activityModelMapper.MapToListModel(entity.Activities).ToObservableCollection()
        };

    public override SubjectEntity MapToEntity(SubjectDetailModel list_model)
        => new()
        {
            Id = list_model.Id,
            Abbr = list_model.SubjectAbbr,
            Name = list_model.SubjectName,
            Credits = list_model.Credits,
            Activities = null!,
            Students = null!
        };
}
