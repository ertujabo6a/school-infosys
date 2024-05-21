using System.Collections.ObjectModel;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class SubjectModelMapper(IStudentModelMapper studentModelMapper, IActivityModelMapper activityModelMapper)
    : ModelMapperBase<SubjectEntity, SubjectListModel, SubjectDetailModel>,
    ISubjectModelMapper
{

    public void setStudentModelMapper(IStudentModelMapper studentMM)
        => studentMM = studentModelMapper;

    public override SubjectListModel MapToListModel(SubjectEntity? entity)
        => entity is null
            ? SubjectListModel.Empty
            : new SubjectListModel
        {
            Id = entity.Id,
            SubjectAbbr = entity.Abbr,
        };

    public SubjectListModel MapToListModel(StudentToSubjectEntity? entity)
        => entity is null
        ? SubjectListModel.Empty
        : new SubjectListModel
        {
            Id = entity.Subject!.Id,
            SubjectAbbr = entity.Subject!.Abbr
        };

    public IEnumerable<SubjectListModel> MapToListModel(IEnumerable<StudentToSubjectEntity> entities)
    {
        var arr = new List<SubjectListModel>();
        foreach (var entity in entities)
            arr.Add(new SubjectListModel
            {
                Id = entity.SubjectId,
                SubjectAbbr = entity.Subject!.Abbr
            });
        return arr;
    }

    public override SubjectDetailModel MapToDetailModel(SubjectEntity? entity)
        => entity is null
            ? SubjectDetailModel.Empty
            : new SubjectDetailModel
        {
            Id = entity.Id,
            SubjectName = entity.Name,
            SubjectAbbr = entity.Abbr,
            Credits = entity.Credits,
            Students = entity.StudentToSubjects != null
                ? studentModelMapper.MapToListModel(entity.StudentToSubjects).ToObservableCollection()
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
            StudentToSubjects = null!
        };
}
