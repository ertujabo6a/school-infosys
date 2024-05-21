using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers.Interfaces;

public interface IStudentToSubjectModelMapper
    : IModelMapper<StudentToSubjectEntity, StudentToSubjectModel, StudentToSubjectModel>
{
    public StudentToSubjectModel MapToModel(StudentDetailModel studentModel, SubjectListModel subjectListModel);
}
