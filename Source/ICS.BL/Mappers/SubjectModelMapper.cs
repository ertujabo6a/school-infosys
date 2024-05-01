using System.Collections.ObjectModel;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class SubjectModelMapper(IStudentModelMapper studentModelMapper, IActivityModelMapper activityModelMapper)
    : ModelMapperBase<SubjectEntity, SubjectListModel, SubjectDetailModel>,
    ISubjectModelMapper
{
    public void SetStudentModelMapper(IStudentModelMapper studModelMapper) => studentModelMapper = studModelMapper;

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
            Students = entity.Students != null
                ? studentModelMapper.MapToListModel(entity.Students).ToObservableCollection()
                : new ObservableCollection<StudentListModel>(),
            Activities = entity.Activities != null
                ? activityModelMapper.MapToListModel(entity.Activities).ToObservableCollection()
                : new ObservableCollection<ActivityListModel>()
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
