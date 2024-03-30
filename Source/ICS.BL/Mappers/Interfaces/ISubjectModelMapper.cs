using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers.Interface;

public interface ISubjectModelMapper
    : IModelMapper<SubjectEntity, SubjectListModel, SubjectReferenceModel>
{
}
