using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers.Interfaces;

public interface IStudentModelMapper
    : IModelMapper<StudentEntity, StudentDetailModel, StudentListModel>
{
}
