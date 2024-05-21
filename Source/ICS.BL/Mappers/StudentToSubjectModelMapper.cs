using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers;

public class StudentToSubjectModelMapper (IStudentModelMapper studentModelMapper, ISubjectModelMapper subjectModelMapper)
    : ModelMapperBase<StudentToSubjectEntity, StudentToSubjectModel, StudentToSubjectModel>,
    IStudentToSubjectModelMapper
{
    private IStudentModelMapper _studentModelMapper = studentModelMapper;
    private ISubjectModelMapper _subjectModelMapper = subjectModelMapper;

    public void SetMappers(IStudentModelMapper studentMM, ISubjectModelMapper subjectMM)
    {
        _studentModelMapper = studentMM;
        _subjectModelMapper = subjectMM;
    }
    public override StudentToSubjectModel MapToListModel(StudentToSubjectEntity? entity)
        => entity is null
        ? StudentToSubjectModel.Empty
        : new StudentToSubjectModel
        {
            Id = entity.Id,
            StudentId = entity.StudentId,
            SubjectId = entity.SubjectId,
            Student = _studentModelMapper.MapToListModel(entity.Student),
            Subject = _subjectModelMapper.MapToListModel(entity.Subject)
        };

    public override StudentToSubjectEntity MapToEntity(StudentToSubjectModel list_model)
        => new()
        {
            Id = list_model.Id,
            StudentId = list_model.StudentId,
            SubjectId = list_model.SubjectId,
            Student = null!,
            Subject = null!
        };

    public StudentToSubjectModel MapToModel(StudentDetailModel studentModel, SubjectListModel subjectListModel)
        => new()
        {
            Id = Guid.NewGuid(),
            StudentId = studentModel.Id,
            Student = null!,
            SubjectId = subjectListModel.Id,
            Subject = null!
        };

    public override StudentToSubjectModel MapToDetailModel(StudentToSubjectEntity entity) => throw new NotImplementedException();

}
