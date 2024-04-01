using ICS.BL.Mappers.Interfaces;
using ICS.BL.Models;
using ICS.DAL.Entities;
using ICS.DAL.Mappers;
using ICS.DAL.UnitOfWork;

namespace ICS.BL.Facades;
public class StudentFacade : FacadeBase<StudentEntity, StudentListModel, StudentReferenceModel, StudentEntityMapper>,
    IStudentFacade
{
    public StudentFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IStudentModelMapper modelMapper) : base(unitOfWorkFactory, modelMapper)
    { }
}
