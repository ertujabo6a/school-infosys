using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;

namespace ICS.BL.Facades;
public class StudentFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IStudentModelMapper modelMapper)
    : FacadeBase<StudentEntity, StudentListModel, StudentReferenceModel, StudentEntityMapper>(unitOfWorkFactory,
        modelMapper), IStudentFacade;
