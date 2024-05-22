using System.Collections;
using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers.Interfaces;

public interface IStudentModelMapper
    : IModelMapper<StudentEntity, StudentListModel, StudentDetailModel>
{
    public IEnumerable<StudentListModel> MapToListModel(IEnumerable<StudentToSubjectEntity> entities);
}
