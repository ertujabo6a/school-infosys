using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Facades.Interfaces;

public interface IStudentToSubjectFacade : IFacade<StudentToSubjectEntity, StudentToSubjectModel, StudentToSubjectModel>
{
    Task<IEnumerable<StudentToSubjectModel>> GetAsync(Guid? studentId);
    Task SaveAsync(StudentDetailModel student);
}
