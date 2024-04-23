using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;

namespace ICS.BL.Facades;
public class SubjectFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    ISubjectModelMapper modelMapper)
    : FacadeBase<SubjectEntity, SubjectDetailModel, SubjectListModel, SubjectEntityMapper>(unitOfWorkFactory,
        modelMapper), ISubjectFacade;
