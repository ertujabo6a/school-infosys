using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;

namespace ICS.BL.Facades;
public class SubjectFacade : FacadeBase<SubjectEntity, SubjectListModel, SubjectReferenceModel, SubjectEntityMapper>,
    ISubjectFacade
{
    public SubjectFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        ISubjectModelMapper modelMapper) : base(unitOfWorkFactory, modelMapper)
    { }
}
