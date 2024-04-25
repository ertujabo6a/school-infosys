using ICS.BL.Models;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;


public class StudentModelMapper(ISubjectModelMapper subjectModelMapper)
    : ModelMapperBase<StudentEntity, StudentListModel, StudentDetailModel>,
    IStudentModelMapper
{
    public override StudentListModel MapToListModel(StudentEntity? entity)
        => entity is null
            ? StudentListModel.Empty
            : new StudentListModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
        };

    public override StudentDetailModel MapToDetailModel(StudentEntity? entity)
        => entity is null
            ? StudentDetailModel.Empty
            : new StudentDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            ImageUrl = entity.ImageUrl,
            Subjects = subjectModelMapper.MapToListModel(entity.Subjects).ToObservableCollection()
        };

    public override StudentEntity MapToEntity(StudentDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            Name = detailModel.Name,
            Surname = detailModel.Surname,
            ImageUrl = detailModel.ImageUrl,
            Subjects = null!,
            Evaluations = null!
        };
}
