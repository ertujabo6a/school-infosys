using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers.Interfaces;

public interface ISubjectModelMapper
    : IModelMapper<SubjectEntity, SubjectListModel, SubjectDetailModel>
{
    public IEnumerable<SubjectListModel> MapToListModel(IEnumerable<StudentToSubjectEntity> entities);
}
