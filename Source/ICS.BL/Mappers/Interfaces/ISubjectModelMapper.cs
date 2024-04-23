using ICS.BL.Models;
using ICS.DAL.Entities;

namespace ICS.BL.Mappers.Interfaces;

public interface ISubjectModelMapper
    : IModelMapper<SubjectEntity, SubjectDetailModel, SubjectListModel>
{
}
